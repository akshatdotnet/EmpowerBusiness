using System.Security.Cryptography;
using System.Text;

namespace Empower.Business
{
    internal class EncryptDecrypt
    {
        private const int AesBlockByteSize = 128 / 8;
        private const int PasswordSaltByteSize = 128 / 8;
        private const int PasswordByteSize = 256 / 8;
        private const int PasswordIterationCount = 100_000;
        private const int SignatureByteSize = 256 / 8;

        private const int MinimumEncryptedMessageByteSize =
            PasswordSaltByteSize + // authentication salt
            PasswordSaltByteSize + // key salt
            AesBlockByteSize + // IV
            AesBlockByteSize + // cipher text min length
            SignatureByteSize; // signature tag

        private static readonly Encoding StringEncoding = Encoding.UTF8;
        private static readonly RandomNumberGenerator Random = RandomNumberGenerator.Create();
        private static readonly string password = "XDE1IyJnNjIbWFb";

        public static string Encrypt(string toEncrypt)
        {
            // encrypt
            var keySalt = GenerateRandomBytes(PasswordSaltByteSize);
            var key = GetKey(password, keySalt);
            var iv = GenerateRandomBytes(AesBlockByteSize);

            byte[] cipherText;
            using (var aes = CreateAes())
            using (var encrypt = aes.CreateEncryptor(key, iv))
            {
                var plainText = StringEncoding.GetBytes(toEncrypt);
                cipherText = encrypt.TransformFinalBlock(plainText, 0, plainText.Length);
            }

            // sign
            var signKeySalt = GenerateRandomBytes(PasswordSaltByteSize);
            var signKey = GetKey(password, signKeySalt);

            var result = MergeArrays(
                additionalCapacity: SignatureByteSize,
                signKeySalt, keySalt, iv, cipherText);

            using (var hashBasedMessageCode = new HMACSHA256(signKey))
            {
                var payloadToSignLength = result.Length - SignatureByteSize;
                var signatureTag = hashBasedMessageCode.ComputeHash(result, 0, payloadToSignLength);
                signatureTag.CopyTo(result, payloadToSignLength);
            }

            return Convert.ToBase64String(result);
        }

        public static string Decrypt(string encryptedDataString)
        {
            if (string.IsNullOrEmpty(encryptedDataString))
            {
                throw new ArgumentException("Invalid length of encrypted data");
            }

            var encryptedData = Convert.FromBase64String(encryptedDataString);

            if (encryptedData is null
                || encryptedData.Length < MinimumEncryptedMessageByteSize)
            {
                throw new ArgumentException("Invalid length of encrypted data");
            }

            var signKeySalt = encryptedData
                .AsSpan(0, PasswordSaltByteSize).ToArray();
            var keySalt = encryptedData
                .AsSpan(PasswordSaltByteSize, PasswordSaltByteSize).ToArray();
            var iv = encryptedData
                .AsSpan(2 * PasswordSaltByteSize, AesBlockByteSize).ToArray();
            var signatureTag = encryptedData
                .AsSpan(encryptedData.Length - SignatureByteSize, SignatureByteSize).ToArray();

            var cipherTextIndex = signKeySalt.Length + keySalt.Length + iv.Length;
            var cipherTextLength =
                encryptedData.Length - cipherTextIndex - signatureTag.Length;

            var authenticationKey = GetKey(password, signKeySalt);
            var key = GetKey(password, keySalt);

            // verify signature
            using (var hashBasedMessageCode = new HMACSHA256(authenticationKey))
            {
                var payloadToSignLength = encryptedData.Length - SignatureByteSize;
                var signatureTagExpected = hashBasedMessageCode
                    .ComputeHash(encryptedData, 0, payloadToSignLength);

                // constant time checking to prevent timing attacks
                var signatureVerificationResult = 0;
                for (int i = 0; i < signatureTag.Length; i++)
                {
                    signatureVerificationResult |= signatureTag[i] ^ signatureTagExpected[i];
                }

                if (signatureVerificationResult != 0)
                {
                    throw new CryptographicException("Invalid signature");
                }
            }

            // decrypt
            using var aes = CreateAes();
            using var encryption = aes.CreateDecryptor(key, iv);
            var decryptedBytes = encryption
                .TransformFinalBlock(encryptedData, cipherTextIndex, cipherTextLength);
            return StringEncoding.GetString(decryptedBytes);
        }

        private static Aes CreateAes()
        {
            var aes = Aes.Create();
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
            return aes;
        }

        private static byte[] GetKey(string password, byte[] passwordSalt)
        {
            var keyBytes = StringEncoding.GetBytes(password);

            using var derivation = new Rfc2898DeriveBytes(
                keyBytes, passwordSalt,
                PasswordIterationCount, HashAlgorithmName.SHA256);
            return derivation.GetBytes(PasswordByteSize);
        }

        private static byte[] GenerateRandomBytes(int numberOfBytes)
        {
            var randomBytes = new byte[numberOfBytes];
            Random.GetBytes(randomBytes);
            return randomBytes;
        }

        private static byte[] MergeArrays(int additionalCapacity = 0, params byte[][] arrays)
        {
            var merged = new byte[arrays.Sum(a => a.Length) + additionalCapacity];
            var mergeIndex = 0;
            for (int i = 0; i < arrays.GetLength(0); i++)
            {
                arrays[i].CopyTo(merged, mergeIndex);
                mergeIndex += arrays[i].Length;
            }

            return merged;
        }




    }
}
