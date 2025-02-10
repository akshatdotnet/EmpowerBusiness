
//const express = require('express');
//const app = express();
//const port = 3001;//3000;1337;
//
//// Default route
//app.get('/', (req, res) => {
//    res.send('Hello, World! This is your Node.js app.');
//});
//
//// Start the server
//app.listen(port, () => {
//    console.log(`Server is running at http://localhost:${port}`);
//});

const express = require('express');
const bodyParser = require('body-parser');
const cors = require('cors');

const app = express();
const port = 1337;


app.get('/', (req, res) => {
    res.send('Hello, World! This is your Node.js app.');
});

// Use CORS middleware
app.use(cors({
    origin: 'https://localhost:7012', // Allow only the client's origin
    methods: ['GET', 'POST', 'PUT', 'DELETE'], // Allow specific methods
    allowedHeaders: ['Content-Type'], // Allow specific headers
}));


// Middleware to parse JSON bodies
app.use(bodyParser.json());

// Mock data
let users = [
    { id: 1, name: "John", email: "john@example.com", role: "Admin" },
    { id: 2, name: "Jane", email: "jane@example.com", role: "User" },
    { id: 3, name: "Sam", email: "sam@example.com", role: "Admin" },
    { id: 4, name: "Anna", email: "anna@example.com", role: "User" },
];


// GET /api/users?page={page}&pageSize={pageSize}&search={searchTerm}&role={role}
app.get('/api/users', (req, res) => {
    const { page = 1, pageSize = 10, search = '', role = '' } = req.query;

    // Filter by search term and role
    let filteredUsers = users.filter(user =>
        user.name.toLowerCase().includes(search.toLowerCase()) &&
        (role ? user.role.toLowerCase() === role.toLowerCase() : true)
    );

    // Paginate the filtered results
    const startIndex = (page - 1) * pageSize;
    const paginatedUsers = filteredUsers.slice(startIndex, startIndex + pageSize);

    res.json({
        page,
        pageSize,
        totalUsers: filteredUsers.length,
        users: paginatedUsers,
    });
});

// POST /api/users
app.post('/api/users', (req, res) => {
    const { name, email, role } = req.body;
    const newUser = { id: users.length + 1, name, email, role };
    users.push(newUser);
    res.status(201).json(newUser);
});

// GET /api/users/{id} - Retrieve user by ID
app.get('/api/users/:id', (req, res) => {
    const { id } = req.params; // Get user ID from URL parameter
    const user = users.find(u => u.id === parseInt(id));

    if (user) {
        res.json(user); // Return the user if found
    } else {
        res.status(404).send({ message: 'User not found' }); // Return 404 if user doesn't exist
    }
});


// PUT /api/users/{id}
app.put('/api/users/:id', (req, res) => {
    const { id } = req.params;
    const { name, email, role } = req.body;

    const userIndex = users.findIndex(user => user.id === parseInt(id));
    if (userIndex !== -1) {
        users[userIndex] = { id: parseInt(id), name, email, role };
        res.json(users[userIndex]);
    } else {
        res.status(404).send({ message: 'User not found' });
    }
});

// DELETE /api/users/{id}
app.delete('/api/users/:id', (req, res) => {
    const { id } = req.params;

    const userIndex = users.findIndex(user => user.id === parseInt(id));
    if (userIndex !== -1) {
        const deletedUser = users.splice(userIndex, 1);
        res.json(deletedUser);
    } else {
        res.status(404).send({ message: 'User not found' });
    }
});

// Start the server
app.listen(port, () => {
    console.log(`Server is running on http://localhost:${port}`);
});
