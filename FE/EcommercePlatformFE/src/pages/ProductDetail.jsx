import { useParams } from 'react-router-dom';

export default function ProductDetail() {
  const { id } = useParams();

  return (
    <div className="min-h-screen py-8">
      <div className="container mx-auto px-4">
        <div className="grid grid-cols-1 lg:grid-cols-2 gap-12">
          {/* Product Image */}
          <div className="space-y-4">
            <div className="h-96 bg-gray-200 rounded-lg flex items-center justify-center">
              <span className="text-gray-500 text-xl">Product Image {id}</span>
            </div>
            <div className="grid grid-cols-4 gap-2">
              {[1, 2, 3, 4].map((thumb) => (
                <div key={thumb} className="h-20 bg-gray-100 rounded cursor-pointer hover:bg-gray-200 transition-colors">
                </div>
              ))}
            </div>
          </div>

          {/* Product Info */}
          <div className="space-y-6">
            <div>
              <h1 className="text-3xl font-bold mb-2">Amazing Product {id}</h1>
              <div className="flex items-center gap-4 mb-4">
                <div className="flex text-yellow-400">
                  {'★'.repeat(5)}
                </div>
                <span className="text-gray-600">(128 reviews)</span>
              </div>
              <p className="text-3xl font-bold text-blue-600 mb-4">$299.99</p>
            </div>

            <div>
              <h3 className="text-lg font-semibold mb-2">Description</h3>
              <p className="text-gray-700 leading-relaxed">
                This is an amazing product with excellent features and high quality materials. 
                Perfect for everyday use and built to last. You'll love the design and functionality 
                that this product offers.
              </p>
            </div>

            <div>
              <h3 className="text-lg font-semibold mb-2">Features</h3>
              <ul className="list-disc list-inside space-y-1 text-gray-700">
                <li>High-quality materials</li>
                <li>Durable construction</li>
                <li>Modern design</li>
                <li>Easy to use</li>
                <li>1-year warranty</li>
              </ul>
            </div>

            <div className="flex items-center gap-4">
              <label className="font-semibold">Quantity:</label>
              <select className="border rounded px-3 py-2">
                {[1, 2, 3, 4, 5].map(num => (
                  <option key={num} value={num}>{num}</option>
                ))}
              </select>
            </div>

            <div className="flex gap-4">
              <button className="flex-1 bg-blue-600 text-white py-3 rounded-lg font-semibold hover:bg-blue-700 transition-colors">
                Add to Cart
              </button>
              <button className="px-6 bg-gray-200 text-gray-800 py-3 rounded-lg font-semibold hover:bg-gray-300 transition-colors">
                ♡
              </button>
            </div>
          </div>
        </div>
      </div>
    </div>
  );
}