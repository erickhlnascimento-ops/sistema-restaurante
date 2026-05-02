/**
 * CARDÁPIO DIGITAL - TOQ D'OURO
 * JavaScript Functionality
 */

// Cart State
let cart = [];
let currentItem = null;

// DOM Elements
const cartItems = document.getElementById('cart-items');
const cartSubtotal = document.getElementById('cart-subtotal');
const cartTotal = document.getElementById('cart-total');
const cartCount = document.querySelector('.cart-count');
const checkoutBtn = document.getElementById('checkout-btn');

// Mobile Elements
const mobileCartBtn = document.getElementById('mobile-cart-btn');
const mobileCartBadge = document.getElementById('mobile-cart-badge');
const cartSheet = document.getElementById('cart-sheet');
const cartSheetOverlay = document.getElementById('cart-sheet-overlay');
const closeSheetBtn = document.getElementById('close-sheet-btn');
const cartSheetItems = document.getElementById('cart-sheet-items');
const cartSheetSubtotal = document.getElementById('cart-sheet-subtotal');
const cartSheetTotal = document.getElementById('cart-sheet-total');
const checkoutSheetBtn = document.getElementById('checkout-sheet-btn');

// Modal Elements
const observationModal = document.getElementById('observation-modal');
const modalItemName = document.getElementById('modal-item-name');
const observationInput = document.getElementById('observation-input');
const modalClose = document.getElementById('modal-close');
const modalCancel = document.getElementById('modal-cancel');
const modalConfirm = document.getElementById('modal-confirm');
const suggestionBtns = document.querySelectorAll('.suggestion-btn');

// Success Modal
const successModal = document.getElementById('success-modal');
const successClose = document.getElementById('success-close');

// Category Buttons
const categoryBtns = document.querySelectorAll('.category-btn');
const menuCards = document.querySelectorAll('.menu-card');

// Menu Items Data (matching HTML)
const menuItemsData = {
  'carpaccio': { name: 'Carpaccio de Carne', price: 42, image: 'images/carpaccio.jpg' },
  'bruschetta': { name: 'Bruschetta Italiana', price: 28, image: 'images/bruschetta.jpg' },
  'camarao-alho': { name: 'Camarão ao Alho', price: 58, image: 'images/camarao-alho.jpg' },
  'file-mignon': { name: 'Filé Mignon ao Molho Madeira', price: 89, image: 'images/file-mignon.jpg' },
  'salmao': { name: 'Salmão Grelhado', price: 78, image: 'images/salmao.jpg' },
  'risoto-camarao': { name: 'Risoto de Camarão', price: 72, image: 'images/risoto-camarao.jpg' },
  'picanha': { name: 'Picanha na Brasa', price: 95, image: 'images/picanha.jpg' },
  'pizza-margherita': { name: 'Pizza Margherita', price: 52, image: 'images/pizza-margherita.jpg' },
  'pizza-4-queijos': { name: 'Pizza Quattro Formaggi', price: 62, image: 'images/pizza-4-queijos.jpg' },
  'pizza-parma': { name: 'Pizza Parma', price: 68, image: 'images/pizza-parma.jpg' },
  'petit-gateau': { name: 'Petit Gâteau', price: 32, image: 'images/petit-gateau.jpg' },
  'tiramisu': { name: 'Tiramisù', price: 28, image: 'images/tiramisu.jpg' },
  'cheesecake': { name: 'Cheesecake de Frutas Vermelhas', price: 26, image: 'images/cheesecake.jpg' },
  'suco': { name: 'Suco Natural', price: 12, image: 'images/suco.jpg' },
  'agua': { name: 'Água Mineral', price: 6, image: 'images/agua.jpg' },
  'refrigerante': { name: 'Refrigerante', price: 8, image: 'images/refrigerante.jpg' },
  'caipirinha': { name: 'Caipirinha', price: 22, image: 'images/caipirinha.jpg' },
  'vinho-tinto': { name: 'Vinho Tinto Malbec', price: 120, image: 'images/vinho-tinto.jpg' },
  'vinho-branco': { name: 'Vinho Branco Chardonnay', price: 95, image: 'images/vinho-branco.jpg' },
  'espumante': { name: 'Espumante Brut', price: 85, image: 'images/espumante.jpg' }
};

// Format currency
function formatCurrency(value) {
  return value.toLocaleString('pt-BR', {
    style: 'currency',
    currency: 'BRL'
  });
}

// Category filtering
categoryBtns.forEach(btn => {
  btn.addEventListener('click', () => {
    // Update active state
    categoryBtns.forEach(b => b.classList.remove('active'));
    btn.classList.add('active');

    const category = btn.dataset.category;

    // Filter cards
    menuCards.forEach(card => {
      if (category === 'all' || card.dataset.category === category) {
        card.classList.remove('hidden');
      } else {
        card.classList.add('hidden');
      }
    });
  });
});

// Add to cart buttons
document.querySelectorAll('.add-btn').forEach(btn => {
  btn.addEventListener('click', () => {
    const itemId = btn.dataset.item;
    const item = menuItemsData[itemId];
    if (item) {
      currentItem = { id: itemId, ...item };
      openObservationModal();
    }
  });
});

// Observation Modal Functions
function openObservationModal() {
  modalItemName.textContent = currentItem.name;
  observationInput.value = '';
  suggestionBtns.forEach(btn => btn.classList.remove('selected'));
  observationModal.classList.add('active');
}

function closeObservationModal() {
  observationModal.classList.remove('active');
  currentItem = null;
}

modalClose.addEventListener('click', closeObservationModal);
modalCancel.addEventListener('click', closeObservationModal);

observationModal.addEventListener('click', (e) => {
  if (e.target === observationModal) {
    closeObservationModal();
  }
});

// Suggestion buttons
suggestionBtns.forEach(btn => {
  btn.addEventListener('click', () => {
    btn.classList.toggle('selected');
    updateObservationFromSuggestions();
  });
});

function updateObservationFromSuggestions() {
  const selected = [];
  suggestionBtns.forEach(btn => {
    if (btn.classList.contains('selected')) {
      selected.push(btn.dataset.obs);
    }
  });
  observationInput.value = selected.join(', ');
}

// Confirm add to cart
modalConfirm.addEventListener('click', () => {
  if (currentItem) {
    addToCart(currentItem, observationInput.value.trim());
    closeObservationModal();
  }
});

// Cart Functions
function addToCart(item, observation = '') {
  const existingIndex = cart.findIndex(
    cartItem => cartItem.id === item.id && cartItem.observation === observation
  );

  if (existingIndex >= 0) {
    cart[existingIndex].quantity++;
  } else {
    cart.push({
      id: item.id,
      name: item.name,
      price: item.price,
      image: item.image,
      observation: observation,
      quantity: 1
    });
  }

  updateCartUI();
  showToast(`${item.name} adicionado ao pedido!`);
}

function removeFromCart(index) {
  cart.splice(index, 1);
  updateCartUI();
}

function updateQuantity(index, delta) {
  cart[index].quantity += delta;
  if (cart[index].quantity <= 0) {
    removeFromCart(index);
  } else {
    updateCartUI();
  }
}

function calculateTotal() {
  return cart.reduce((sum, item) => sum + (item.price * item.quantity), 0);
}

function updateCartUI() {
  const total = calculateTotal();
  const itemCount = cart.reduce((sum, item) => sum + item.quantity, 0);

  // Update counts
  cartCount.textContent = `${itemCount} ${itemCount === 1 ? 'item' : 'itens'}`;
  mobileCartBadge.textContent = itemCount;

  // Update totals
  cartSubtotal.textContent = formatCurrency(total);
  cartTotal.textContent = formatCurrency(total);
  cartSheetSubtotal.textContent = formatCurrency(total);
  cartSheetTotal.textContent = formatCurrency(total);

  // Update buttons
  checkoutBtn.disabled = cart.length === 0;
  checkoutSheetBtn.disabled = cart.length === 0;

  // Render cart items
  renderCartItems(cartItems);
  renderCartItems(cartSheetItems);
}

function renderCartItems(container) {
  if (cart.length === 0) {
    container.innerHTML = `
      <div class="cart-empty">
        <svg width="48" height="48" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5">
          <circle cx="9" cy="21" r="1"/>
          <circle cx="20" cy="21" r="1"/>
          <path d="M1 1h4l2.68 13.39a2 2 0 0 0 2 1.61h9.72a2 2 0 0 0 2-1.61L23 6H6"/>
        </svg>
        <p>Seu carrinho está vazio</p>
        <span>Adicione itens do cardápio</span>
      </div>
    `;
    return;
  }

  container.innerHTML = cart.map((item, index) => `
    <div class="cart-item">
      <div class="cart-item-image">
        <img src="${item.image}" alt="${item.name}">
      </div>
      <div class="cart-item-info">
        <div class="cart-item-name">${item.name}</div>
        ${item.observation ? `<div class="cart-item-obs">${item.observation}</div>` : ''}
        <div class="cart-item-price">${formatCurrency(item.price * item.quantity)}</div>
      </div>
      <div class="cart-item-actions">
        <div class="quantity-controls">
          <button class="qty-btn" onclick="updateQuantity(${index}, -1)">−</button>
          <span class="qty-value">${item.quantity}</span>
          <button class="qty-btn" onclick="updateQuantity(${index}, 1)">+</button>
        </div>
        <button class="remove-btn" onclick="removeFromCart(${index})">Remover</button>
      </div>
    </div>
  `).join('');
}

// Mobile Cart Sheet
mobileCartBtn.addEventListener('click', openCartSheet);
closeSheetBtn.addEventListener('click', closeCartSheet);
cartSheetOverlay.addEventListener('click', closeCartSheet);

function openCartSheet() {
  cartSheet.classList.add('active');
  cartSheetOverlay.classList.add('active');
  document.body.style.overflow = 'hidden';
}

function closeCartSheet() {
  cartSheet.classList.remove('active');
  cartSheetOverlay.classList.remove('active');
  document.body.style.overflow = '';
}

// Checkout
checkoutBtn.addEventListener('click', submitOrder);
checkoutSheetBtn.addEventListener('click', submitOrder);

function submitOrder() {
  if (cart.length === 0) return;

  closeCartSheet();
  successModal.classList.add('active');
}

successClose.addEventListener('click', () => {
  successModal.classList.remove('active');
  cart = [];
  updateCartUI();
});

successModal.addEventListener('click', (e) => {
  if (e.target === successModal) {
    successModal.classList.remove('active');
    cart = [];
    updateCartUI();
  }
});

// Toast notification
function showToast(message) {
  // Create toast element
  const toast = document.createElement('div');
  toast.style.cssText = `
    position: fixed;
    top: 100px;
    left: 50%;
    transform: translateX(-50%);
    background-color: #16a34a;
    color: white;
    padding: 12px 24px;
    border-radius: 8px;
    font-size: 14px;
    font-weight: 500;
    z-index: 9999;
    box-shadow: 0 4px 12px rgba(0,0,0,0.15);
    animation: toastIn 0.3s ease;
  `;
  toast.textContent = message;

  // Add animation styles
  const style = document.createElement('style');
  style.textContent = `
    @keyframes toastIn {
      from { opacity: 0; transform: translate(-50%, -20px); }
      to { opacity: 1; transform: translate(-50%, 0); }
    }
    @keyframes toastOut {
      from { opacity: 1; transform: translate(-50%, 0); }
      to { opacity: 0; transform: translate(-50%, -20px); }
    }
  `;
  document.head.appendChild(style);

  document.body.appendChild(toast);

  // Remove after 2 seconds
  setTimeout(() => {
    toast.style.animation = 'toastOut 0.3s ease';
    setTimeout(() => {
      toast.remove();
    }, 300);
  }, 2000);
}

// Initialize
updateCartUI();