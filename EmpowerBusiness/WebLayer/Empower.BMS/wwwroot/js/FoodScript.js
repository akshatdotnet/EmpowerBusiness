// Mock Data
const restaurants = [
    {
        id: 1,
        name: "Pizza Palace",
        cuisine: "Italian",
        rating: 4.5,
        menu: [
            { name: "Margherita Pizza", price: 10 },
            { name: "Pepperoni Pizza", price: 12 }
        ]
    },
    {
        id: 2,
        name: "Burger Hub",
        cuisine: "American",
        rating: 4.7,
        menu: [
            { name: "Classic Burger", price: 8 },
            { name: "Cheese Burger", price: 9 }
        ]
    },
    {
        id: 3,
        name: "Curry Corner",
        cuisine: "Indian",
        rating: 4.8,
        menu: [
            { name: "Butter Chicken", price: 14 },
            { name: "Paneer Tikka", price: 12 }
        ]
    }
];

const cart = [];

// Render Restaurants
const restaurantList = document.getElementById("restaurant-list");

restaurants.forEach((restaurant) => {
    const card = document.createElement("div");
    card.className = "restaurant-card";
    card.innerHTML = `
    <h3>${restaurant.name}</h3>
    <p>Cuisine: ${restaurant.cuisine}</p>
    <p>Rating: ${restaurant.rating}</p>
    <button onclick="showMenu(${restaurant.id})">View Menu</button>
  `;
    restaurantList.appendChild(card);
});

// Show Menu and Add to Cart
function showMenu(restaurantId) {
    const selectedRestaurant = restaurants.find(r => r.id === restaurantId);
    const menuHtml = selectedRestaurant.menu.map(item => `
    <div>
      <p>${item.name} - $${item.price}</p>
      <button onclick="addToCart('${item.name}', ${item.price})">Add to Cart</button>
    </div>
  `).join('');
    alert(`Menu:\n${menuHtml}`);
}

// Add to Cart
function addToCart(name, price) {
    cart.push({ name, price });
    renderCart();
}

// Render Cart
function renderCart() {
    const cartItems = document.getElementById("cart-items");
    const cartTotal = document.getElementById("cart-total");

    cartItems.innerHTML = cart.map(item => `
    <div class="cart-item">
      <p>${item.name} - $${item.price}</p>
    </div>
  `).join('');

    const total = cart.reduce((sum, item) => sum + item.price, 0);
    cartTotal.textContent = total.toFixed(2);
}
