export default function Profile() {
  return (
    <div className="min-h-screen py-8">
      <div className="container mx-auto px-4">
        <div className="max-w-4xl mx-auto">
          <h1 className="text-3xl font-bold mb-8">My Profile</h1>
          
          <div className="grid grid-cols-1 lg:grid-cols-3 gap-8">
            {/* Profile Info */}
            <div className="lg:col-span-2 space-y-6">
              <div className="bg-white rounded-lg shadow p-6">
                <h2 className="text-xl font-semibold mb-4">Personal Information</h2>
                <div className="grid grid-cols-1 md:grid-cols-2 gap-4">
                  <div>
                    <label className="block text-sm font-medium mb-1">First Name</label>
                    <input type="text" className="w-full border rounded-lg px-3 py-2" defaultValue="John" />
                  </div>
                  <div>
                    <label className="block text-sm font-medium mb-1">Last Name</label>
                    <input type="text" className="w-full border rounded-lg px-3 py-2" defaultValue="Doe" />
                  </div>
                  <div>
                    <label className="block text-sm font-medium mb-1">Email</label>
                    <input type="email" className="w-full border rounded-lg px-3 py-2" defaultValue="john.doe@example.com" />
                  </div>
                  <div>
                    <label className="block text-sm font-medium mb-1">Phone</label>
                    <input type="tel" className="w-full border rounded-lg px-3 py-2" defaultValue="+1 (555) 123-4567" />
                  </div>
                </div>
                <button className="mt-4 bg-blue-600 text-white px-6 py-2 rounded-lg hover:bg-blue-700 transition-colors">
                  Update Profile
                </button>
              </div>

              <div className="bg-white rounded-lg shadow p-6">
                <h2 className="text-xl font-semibold mb-4">Shipping Address</h2>
                <div className="space-y-4">
                  <div>
                    <label className="block text-sm font-medium mb-1">Street Address</label>
                    <input type="text" className="w-full border rounded-lg px-3 py-2" defaultValue="123 Main St" />
                  </div>
                  <div className="grid grid-cols-1 md:grid-cols-3 gap-4">
                    <div>
                      <label className="block text-sm font-medium mb-1">City</label>
                      <input type="text" className="w-full border rounded-lg px-3 py-2" defaultValue="New York" />
                    </div>
                    <div>
                      <label className="block text-sm font-medium mb-1">State</label>
                      <input type="text" className="w-full border rounded-lg px-3 py-2" defaultValue="NY" />
                    </div>
                    <div>
                      <label className="block text-sm font-medium mb-1">ZIP Code</label>
                      <input type="text" className="w-full border rounded-lg px-3 py-2" defaultValue="10001" />
                    </div>
                  </div>
                </div>
                <button className="mt-4 bg-blue-600 text-white px-6 py-2 rounded-lg hover:bg-blue-700 transition-colors">
                  Update Address
                </button>
              </div>
            </div>

            {/* Profile Stats */}
            <div className="space-y-6">
              <div className="bg-white rounded-lg shadow p-6 text-center">
                <div className="w-24 h-24 bg-gray-200 rounded-full mx-auto mb-4"></div>
                <h3 className="text-lg font-semibold">John Doe</h3>
                <p className="text-gray-600">Customer since 2023</p>
              </div>

              <div className="bg-white rounded-lg shadow p-6">
                <h3 className="text-lg font-semibold mb-4">Order Statistics</h3>
                <div className="space-y-3">
                  <div className="flex justify-between">
                    <span>Total Orders:</span>
                    <span className="font-semibold">24</span>
                  </div>
                  <div className="flex justify-between">
                    <span>Total Spent:</span>
                    <span className="font-semibold">$2,847.50</span>
                  </div>
                  <div className="flex justify-between">
                    <span>Favorite Category:</span>
                    <span className="font-semibold">Electronics</span>
                  </div>
                </div>
              </div>

              <div className="bg-white rounded-lg shadow p-6">
                <h3 className="text-lg font-semibold mb-4">Recent Orders</h3>
                <div className="space-y-3">
                  <div className="border-b pb-2">
                    <p className="font-medium">Order #1234</p>
                    <p className="text-sm text-gray-600">$299.99 - Delivered</p>
                  </div>
                  <div className="border-b pb-2">
                    <p className="font-medium">Order #1233</p>
                    <p className="text-sm text-gray-600">$199.99 - Shipped</p>
                  </div>
                  <div>
                    <p className="font-medium">Order #1232</p>
                    <p className="text-sm text-gray-600">$89.99 - Processing</p>
                  </div>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}