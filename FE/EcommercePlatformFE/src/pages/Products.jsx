import { useState } from 'react';
import { Link } from 'react-router-dom';
import { Row, Col, Card, Button, Typography, Select, Space, Tag, Rate, Pagination } from 'antd';
import { ShoppingCartOutlined, EyeOutlined } from '@ant-design/icons';

const { Title, Paragraph } = Typography;
const { Meta } = Card;
const { Option } = Select;

export default function Products() {
  const [currentPage, setCurrentPage] = useState(1);
  const [selectedCategory, setSelectedCategory] = useState('All');
  const [sortBy, setSortBy] = useState('name');

  const products = [
    { id: 1, name: 'Laptop Pro', price: 1299.99, category: 'Electronics', rating: 4.8, reviews: 124, image: '💻' },
    { id: 2, name: 'Wireless Headphones', price: 199.99, category: 'Electronics', rating: 4.6, reviews: 89, image: '🎧' },
    { id: 3, name: 'Smart Watch', price: 299.99, category: 'Electronics', rating: 4.7, reviews: 156, image: '⌚' },
    { id: 4, name: 'Gaming Chair', price: 399.99, category: 'Furniture', rating: 4.5, reviews: 67, image: '🪑' },
    { id: 5, name: 'Coffee Maker', price: 89.99, category: 'Appliances', rating: 4.3, reviews: 234, image: '☕' },
    { id: 6, name: 'Running Shoes', price: 129.99, category: 'Sports', rating: 4.4, reviews: 78, image: '👟' },
    { id: 7, name: 'Smartphone', price: 899.99, category: 'Electronics', rating: 4.9, reviews: 345, image: '📱' },
    { id: 8, name: 'Desk Lamp', price: 59.99, category: 'Furniture', rating: 4.2, reviews: 45, image: '💡' },
  ];

  const categories = ['All', 'Electronics', 'Furniture', 'Appliances', 'Sports'];

  const filteredProducts = products.filter(product => 
    selectedCategory === 'All' || product.category === selectedCategory
  );

  const sortedProducts = [...filteredProducts].sort((a, b) => {
    switch (sortBy) {
      case 'price-low':
        return a.price - b.price;
      case 'price-high':
        return b.price - a.price;
      case 'rating':
        return b.rating - a.rating;
      default:
        return a.name.localeCompare(b.name);
    }
  });

  const itemsPerPage = 6;
  const startIndex = (currentPage - 1) * itemsPerPage;
  const currentProducts = sortedProducts.slice(startIndex, startIndex + itemsPerPage);

  return (
    <div style={{ minHeight: '100vh', padding: '24px' }}>
      <div style={{ maxWidth: 1200, margin: '0 auto' }}>
        
        {/* Header */}
        <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'center', marginBottom: 32 }}>
          <Title level={2}>All Products ({filteredProducts.length})</Title>
          
          <Space size="middle">
            <Select
              value={selectedCategory}
              onChange={setSelectedCategory}
              style={{ width: 150 }}
            >
              {categories.map(category => (
                <Option key={category} value={category}>{category}</Option>
              ))}
            </Select>
            
            <Select
              value={sortBy}
              onChange={setSortBy}
              style={{ width: 150 }}
            >
              <Option value="name">Sort by Name</Option>
              <Option value="price-low">Price: Low to High</Option>
              <Option value="price-high">Price: High to Low</Option>
              <Option value="rating">Highest Rated</Option>
            </Select>
          </Space>
        </div>

        {/* Products Grid */}
        <Row gutter={[24, 24]} style={{ marginBottom: 32 }}>
          {currentProducts.map((product) => (
            <Col xs={24} sm={12} lg={8} key={product.id}>
              <Card
                hoverable
                cover={
                  <div style={{ 
                    height: 200, 
                    display: 'flex', 
                    alignItems: 'center', 
                    justifyContent: 'center',
                    fontSize: '4rem',
                    background: 'linear-gradient(135deg, #f5f7fa 0%, #c3cfe2 100%)'
                  }}>
                    {product.image}
                  </div>
                }
                actions={[
                  <Link to={`/products/${product.id}`} key="view">
                    <Button type="default" icon={<EyeOutlined />}>
                      View
                    </Button>
                  </Link>,
                  <Button 
                    key="cart" 
                    type="primary" 
                    icon={<ShoppingCartOutlined />}
                    onClick={() => console.log('Add to cart:', product.id)}
                  >
                    Add to Cart
                  </Button>
                ]}
              >
                <Meta
                  title={
                    <div style={{ display: 'flex', justifyContent: 'space-between', alignItems: 'start' }}>
                      <span>{product.name}</span>
                      <Tag color="blue">{product.category}</Tag>
                    </div>
                  }
                  description={
                    <Space direction="vertical" size="small" style={{ width: '100%' }}>
                      <div>
                        <Rate disabled defaultValue={product.rating} allowHalf />
                        <span style={{ marginLeft: 8, color: '#666' }}>
                          {product.rating} ({product.reviews} reviews)
                        </span>
                      </div>
                      <Paragraph ellipsis={{ rows: 2 }}>
                        High-quality product with excellent features and great value for money.
                      </Paragraph>
                      <div style={{ fontSize: '1.5rem', fontWeight: 'bold', color: '#1890ff' }}>
                        ${product.price}
                      </div>
                    </Space>
                  }
                />
              </Card>
            </Col>
          ))}
        </Row>

        {/* Pagination */}
        <div style={{ textAlign: 'center' }}>
          <Pagination
            current={currentPage}
            total={filteredProducts.length}
            pageSize={itemsPerPage}
            onChange={setCurrentPage}
            showSizeChanger={false}
            showQuickJumper
            showTotal={(total, range) => 
              `${range[0]}-${range[1]} of ${total} products`
            }
          />
        </div>
      </div>
    </div>
  );
}