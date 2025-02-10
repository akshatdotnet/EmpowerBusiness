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

// DOM Elements
const restaurantList = document.getElementById("restaurant-list");
const cartItems = document.getElementById("cart-items");
const cartTotal = document.getElementById("cart-total");

// Utility Functions
const createElement = (tag, className, innerHTML = "") => {
    const element = document.createElement(tag);
    if (className) element.className = className;
    if (innerHTML) element.innerHTML = innerHTML;
    return element;
};

// Render Restaurants
const renderRestaurants = () => {
    restaurantList.innerHTML = ""; // Clear existing content
    restaurants.forEach((restaurant) => {
        const card = createElement("div", "restaurant-card");
        card.innerHTML = `
      <h3>${restaurant.name}</h3>
      <p>Cuisine: ${restaurant.cuisine}</p>
      <p>Rating: ${restaurant.rating}</p>
      <button data-id="${restaurant.id}" class="view-menu-btn">View Menu</button>
    `;
        restaurantList.appendChild(card);
    });
};

//const renderRestaurants = () => {
//    restaurantList.innerHTML = ""; // Clear existing content
//    restaurants.forEach((restaurant) => {
//        const card = createElement("div", "restaurant-card");
//        card.innerHTML = `
//      <h3>${restaurant.name}</h3>
//      <p>Cuisine: ${restaurant.cuisine}</p>
//      <p>Rating: ${restaurant.rating}</p>
//      <button id="view-menu-${restaurant.id}" data-id="${restaurant.id}" class="view-menu-btn">
//        View Menu
//      </button>
//    `;
//        restaurantList.appendChild(card);
//    });
//};


// Show Menu and Add to Cart
const showMenu = (restaurantId) => {
    const selectedRestaurant = restaurants.find((r) => r.id === restaurantId);
    if (!selectedRestaurant) {
        alert("Restaurant not found.");
        return;
    }

    const menuHtml = selectedRestaurant.menu
        .map(
            (item) => `
      <div>
        <p>${item.name} - $${item.price}</p>
        <button class="add-to-cart-btn" data-name="${item.name}" data-price="${item.price}">
          Add to Cart
        </button>
      </div>
    `
        )
        .join("");
    alert(`Menu:\n${menuHtml}`);
};

// Add to Cart
const addToCart = (name, price) => {
    cart.push({ name, price });
    renderCart();
};

// Render Cart
const renderCart = () => {
    cartItems.innerHTML = cart
        .map(
            (item) => `
    <div class="cart-item">
      <p>${item.name} - $${item.price}</p>
    </div>
  `
        )
        .join("");

    const total = cart.reduce((sum, item) => sum + item.price, 0);
    cartTotal.textContent = total.toFixed(2);
};

// Event Listeners
restaurantList.addEventListener("click", (event) => {
    if (event.target.classList.contains("view-menu-btn")) {
        const restaurantId = parseInt(event.target.dataset.id, 10);
        showMenu(restaurantId);
    }
});

document.addEventListener("click", (event) => {
    if (event.target.classList.contains("add-to-cart-btn")) {
        const name = event.target.dataset.name;
        const price = parseFloat(event.target.dataset.price);
        addToCart(name, price);
    }
});

// Initial Render
renderRestaurants();
