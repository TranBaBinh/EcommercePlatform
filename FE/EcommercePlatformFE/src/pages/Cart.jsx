export default function Cart() {
  const cartItems = [
    { id: 1, name: 'Laptop Pro', price: 1299.99, quantity: 1, image: 'laptop.jpg' },
    { id: 2, name: 'Wireless Headphones', price: 199.99, quantity: 2, image: 'headphones.jpg' },
    { id: 3, name: 'Smart Watch', price: 299.99, quantity: 1, image: 'watch.jpg' },
  ];

  const total = cartItems.reduce((sum, item) => sum + (item.price * item.quantity), 0);

  return (
    <div className="min-h-screen py-8">
      <div className="container mx-auto px-4">
        <h1 className="text-3xl font-bold mb-8">Shopping Cart</h1>
        
        {cartItems.length === 0 ? (
          <div className="text-center py-16">
            <p className="text-gray-600 mb-4">Your cart is empty</p>
            <button className="bg-blue-600 text-white px-6 py-3 rounded-lg hover:bg-blue-700 transition-colors">
              Continue Shopping
            </button>
          </div>
        ) : (
          <div className="grid grid-cols-1 lg:grid-cols-3 gap-8">
            {/* Cart Items */}
            <div className="lg:col-span-2 space-y-4">
              {cartItems.map((item) => (
                <div key={item.id} className="bg-white rounded-lg shadow p-6">
                  <div className="flex items-center gap-4">
                    <div className="w-20 h-20 bg-gray-200 rounded flex-shrink-0"></div>
                    <div className="flex-1">
                      <h3 className="text-lg font-semibold">{item.name}</h3>
                      <p className="text-gray-600">In Stock</p>
                    </div>
                    <div className="text-right">
                      <p className="text-lg font-semibold">${item.price}</p>
                      <div className="flex items-center gap-2 mt-2">
                        <button className="w-8 h-8 border rounded flex items-center justify-center hover:bg-gray-100">
                          -
                        </button>
                        <span className="w-12 text-center">{item.quantity}</span>
                        <button className="w-8 h-8 border rounded flex items-center justify-center hover:bg-gray-100">
                          +
                        </button>
                      </div>
                    </div>
                    <button className="text-red-500 hover:text-red-700 ml-4">
                      Remove
                    </button>
                  </div>
                </div>
              ))}
            </div>

            {/* Order Summary */}
            <div className="bg-white rounded-lg shadow p-6 h-fit">
              <h2 className="text-xl font-semibold mb-4">Order Summary</h2>
              <div className="space-y-2 mb-4">
                <div className="flex justify-between">
                  <span>Subtotal:</span>
                  <span>${total.toFixed(2)}</span>
                </div>
                <div className="flex justify-between">
                  <span>Shipping:</span>
                  <span>$9.99</span>
                </div>
                <div className="flex justify-between">
                  <span>Tax:</span>
                  <span>${(total * 0.08).toFixed(2)}</span>
                </div>
                <hr className="my-2" />
                <div className="flex justify-between font-semibold text-lg">
                  <span>Total:</span>
                  <span>${(total + 9.99 + (total * 0.08)).toFixed(2)}</span>
                </div>
              </div>
              <button className="w-full bg-blue-600 text-white py-3 rounded-lg font-semibold hover:bg-blue-700 transition-colors">
                Proceed to Checkout
              </button>
            </div>
          </div>
        )}
      </div>
    </div>
  );
}