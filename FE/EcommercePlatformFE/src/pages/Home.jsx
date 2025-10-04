import { Link } from 'react-router-dom';
import { Row, Col, Card, Button, Typography, Space, Carousel, Badge, Rate } from 'antd';
import { 
  ShoppingCartOutlined, 
  HeartOutlined,
  EyeOutlined,
  FireOutlined,
  SafetyCertificateOutlined, 
  TruckOutlined,
  StarOutlined,
  RightOutlined
} from '@ant-design/icons';

const { Title, Paragraph, Text } = Typography;

export default function Home() {
  // Banner data for carousel
  const bannerData = [
    {
      id: 1,
      title: "MEGA SALE",
      subtitle: "Up to 70% OFF",
      description: "Electronics & Gadgets",
      image: "https://images.unsplash.com/photo-1607082348824-0a96f2a4b9da?w=1200&h=400&fit=crop",
      color: "#ff4757"
    },
    {
      id: 2,
      title: "NEW ARRIVALS",
      subtitle: "Fashion Week Special",
      description: "Latest trends for 2024",
      image: "https://images.unsplash.com/photo-1441986300917-64674bd600d8?w=1200&h=400&fit=crop",
      color: "#5f27cd"
    },
    {
      id: 3,
      title: "HOME & LIVING",
      subtitle: "Cozy Up Your Space",
      description: "Free shipping on furniture",
      image: "https://images.unsplash.com/photo-1586023492125-27b2c045efd7?w=1200&h=400&fit=crop",
      color: "#00d2d3"
    }
  ];

  // Flash sale products
  const flashSaleProducts = [
    {
      id: 1,
      name: "iPhone 15 Pro Max",
      price: 999,
      originalPrice: 1199,
      image: "https://images.unsplash.com/photo-1510557880182-3d4d3cba35a5?w=300&h=300&fit=crop",
      discount: 17,
      sold: 234,
      rating: 4.8,
      reviews: 1250
    },
    {
      id: 2,
      name: "Samsung 55\" 4K TV",
      price: 699,
      originalPrice: 899,
      image: "https://images.unsplash.com/photo-1593359677879-a4bb92f829d1?w=300&h=300&fit=crop",
      discount: 22,
      sold: 89,
      rating: 4.6,
      reviews: 420
    },
    {
      id: 3,
      name: "Nike Air Jordan",
      price: 149,
      originalPrice: 199,
      image: "https://images.unsplash.com/photo-1542291026-7eec264c27ff?w=300&h=300&fit=crop",
      discount: 25,
      sold: 156,
      rating: 4.9,
      reviews: 890
    },
    {
      id: 4,
      name: "MacBook Air M2",
      price: 1099,
      originalPrice: 1299,
      image: "https://images.unsplash.com/photo-1517336714731-489689fd1ca8?w=300&h=300&fit=crop",
      discount: 15,
      sold: 67,
      rating: 4.7,
      reviews: 340
    },
    {
      id: 5,
      name: "AirPods Pro 2",
      price: 199,
      originalPrice: 249,
      image: "https://images.unsplash.com/photo-1572569511254-d8f925fe2cbb?w=300&h=300&fit=crop",
      discount: 20,
      sold: 445,
      rating: 4.8,
      reviews: 670
    },
    {
      id: 6,
      name: "Sony WH-1000XM5 Headphones",
      price: 299,
      originalPrice: 399,
      image: "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?w=300&h=300&fit=crop",
      discount: 25,
      sold: 167,
      rating: 4.9,
      reviews: 1340
    },
    {
      id: 7,
      name: "iPad Air 5th Gen",
      price: 499,
      originalPrice: 599,
      image: "https://images.unsplash.com/photo-1544244015-0df4b3ffc6b0?w=300&h=300&fit=crop",
      discount: 17,
      sold: 98,
      rating: 4.7,
      reviews: 567
    },
    {
      id: 8,
      name: "Gaming Mechanical Keyboard",
      price: 89,
      originalPrice: 129,
      image: "https://images.unsplash.com/photo-1541140532154-b024d705b90a?w=300&h=300&fit=crop",
      discount: 31,
      sold: 234,
      rating: 4.6,
      reviews: 892
    },
    {
      id: 9,
      name: "Wireless Mouse",
      price: 45,
      originalPrice: 65,
      image: "https://images.unsplash.com/photo-1527864550417-7fd91fc51a46?w=300&h=300&fit=crop",
      discount: 31,
      sold: 456,
      rating: 4.4,
      reviews: 456
    },
    {
      id: 10,
      name: "Bluetooth Speaker Portable",
      price: 79,
      originalPrice: 99,
      image: "https://images.unsplash.com/photo-1608043152269-423dbba4e7e1?w=300&h=300&fit=crop",
      discount: 20,
      sold: 678,
      rating: 4.7,
      reviews: 678
    }
  ];

  // Categories
  const categories = [
    { id: 1, name: "Electronics", icon: "�", color: "#3742fa" },
    { id: 2, name: "Fashion", icon: "👕", color: "#ff6b6b" },
    { id: 3, name: "Home & Living", icon: "🏠", color: "#26de81" },
    { id: 4, name: "Beauty", icon: "💄", color: "#fd79a8" },
    { id: 5, name: "Sports", icon: "⚽", color: "#f39c12" },
    { id: 6, name: "Books", icon: "📚", color: "#6c5ce7" },
    { id: 7, name: "Automotive", icon: "🚗", color: "#a29bfe" },
    { id: 8, name: "Toys", icon: "�", color: "#fd63c2" }
  ];

  return (
    <div>
      {/* Hero Carousel */}
      <div style={{ marginBottom: '30px' }}>
        <Carousel autoplay effect="fade">
          {bannerData.map(banner => (
            <div key={banner.id}>
              <div style={{ 
                height: '400px', 
                background: `linear-gradient(rgba(0,0,0,0.4), rgba(0,0,0,0.4)), url(${banner.image})`,
                backgroundSize: 'cover',
                backgroundPosition: 'center',
                display: 'flex',
                alignItems: 'center',
                justifyContent: 'center',
                color: 'white',
                textAlign: 'center'
              }}>
                <div>
                  <Title level={1} style={{ color: 'white', fontSize: '48px', marginBottom: '8px' }}>
                    {banner.title}
                  </Title>
                  <Title level={2} style={{ color: banner.color, marginBottom: '16px' }}>
                    {banner.subtitle}
                  </Title>
                  <Paragraph style={{ color: 'white', fontSize: '18px', marginBottom: '24px' }}>
                    {banner.description}
                  </Paragraph>
                  <Button type="primary" size="large" style={{ backgroundColor: banner.color, borderColor: banner.color }}>
                    Shop Now
                  </Button>
                </div>
              </div>
            </div>
          ))}
        </Carousel>
      </div>

      <div style={{ maxWidth: 1200, margin: '0 auto', padding: '0 16px' }}>
        {/* Categories */}
        <div style={{ marginBottom: '40px' }}>
          <Title level={3} style={{ marginBottom: '20px' }}>Shop by Category</Title>
          <Row gutter={[16, 16]}>
            {categories.map(category => (
              <Col xs={12} sm={8} md={6} lg={3} key={category.id}>
                <Card 
                  hoverable 
                  style={{ textAlign: 'center', border: '1px solid #f0f0f0' }}
                  bodyStyle={{ padding: '20px 12px' }}
                >
                  <div style={{ 
                    fontSize: '32px', 
                    marginBottom: '8px',
                    padding: '16px',
                    backgroundColor: category.color + '20',
                    borderRadius: '50%',
                    width: '64px',
                    height: '64px',
                    margin: '0 auto',
                    display: 'flex',
                    alignItems: 'center',
                    justifyContent: 'center'
                  }}>
                    {category.icon}
                  </div>
                  <Text strong>{category.name}</Text>
                </Card>
              </Col>
            ))}
          </Row>
        </div>

        {/* Flash Sale Section */}
        <div style={{ marginBottom: '40px', boxShadow: '0 4px 12px rgba(0,0,0,0.1)', borderRadius: '12px', overflow: 'hidden' }}>
          <div style={{ 
            background: 'linear-gradient(135deg, #ff6b6b 0%, #ee5a52 50%, #ff4757 100%)',
            padding: '20px 24px',
            position: 'relative',
            overflow: 'hidden'
          }}>
            {/* Background decoration */}
            <div style={{
              position: 'absolute',
              top: '-50px',
              right: '-50px',
              width: '150px',
              height: '150px',
              background: 'rgba(255,255,255,0.1)',
              borderRadius: '50%'
            }}></div>
            <div style={{
              position: 'absolute',
              bottom: '-30px',
              left: '-30px',
              width: '100px',
              height: '100px',
              background: 'rgba(255,255,255,0.05)',
              borderRadius: '50%'
            }}></div>
            
            <Row justify="space-between" align="middle">
              <Col>
                <Space size="large">
                  <div style={{ display: 'flex', alignItems: 'center', gap: '12px' }}>
                    <div style={{
                      width: '48px',
                      height: '48px',
                      background: 'rgba(255,255,255,0.2)',
                      borderRadius: '50%',
                      display: 'flex',
                      alignItems: 'center',
                      justifyContent: 'center'
                    }}>
                      <FireOutlined style={{ fontSize: '24px', color: 'white' }} />
                    </div>
                    <div>
                      <Title level={2} style={{ color: 'white', margin: 0, fontWeight: 'bold', textShadow: '0 2px 4px rgba(0,0,0,0.3)' }}>
                        ⚡ FLASH SALE
                      </Title>
                      <Text style={{ color: 'rgba(255,255,255,0.9)', fontSize: '14px' }}>
                        Limited time offers - Don't miss out!
                      </Text>
                    </div>
                  </div>
                  <div style={{
                    background: 'rgba(255,235,59,0.9)',
                    color: '#d32f2f',
                    padding: '6px 12px',
                    borderRadius: '20px',
                    fontSize: '12px',
                    fontWeight: 'bold',
                    textTransform: 'uppercase',
                    letterSpacing: '0.5px',
                    animation: 'pulse 2s infinite'
                  }}>
                    🔥 HOT DEALS
                  </div>
                </Space>
              </Col>
              <Col>
                <Space direction="vertical" align="end" size="small">
                  <div style={{ color: 'rgba(255,255,255,0.9)', fontSize: '12px', textAlign: 'right' }}>
                    ⏰ Ends in:
                  </div>
                  <div style={{
                    display: 'flex',
                    gap: '8px',
                    alignItems: 'center'
                  }}>
                    {[
                      { label: 'H', value: '23' },
                      { label: 'M', value: '45' },
                      { label: 'S', value: '12' }
                    ].map((time, index) => (
                      <div key={index} style={{
                        background: 'rgba(255,255,255,0.2)',
                        backdropFilter: 'blur(10px)',
                        borderRadius: '8px',
                        padding: '8px 6px',
                        minWidth: '40px',
                        textAlign: 'center',
                        border: '1px solid rgba(255,255,255,0.3)'
                      }}>
                        <div style={{ color: 'white', fontSize: '16px', fontWeight: 'bold', lineHeight: '1' }}>
                          {time.value}
                        </div>
                        <div style={{ color: 'rgba(255,255,255,0.8)', fontSize: '10px', lineHeight: '1' }}>
                          {time.label}
                        </div>
                      </div>
                    ))}
                  </div>
                  <Button 
                    type="primary" 
                    ghost 
                    size="small"
                    style={{ 
                      borderColor: 'white', 
                      color: 'white',
                      fontWeight: 'bold',
                      background: 'rgba(255,255,255,0.1)',
                      backdropFilter: 'blur(10px)'
                    }}
                  >
                    View All {'>'}
                  </Button>
                </Space>
              </Col>
            </Row>
          </div>
          
          <div style={{ backgroundColor: 'white', padding: '20px' }}>
            <Row gutter={[16, 16]}>
              {flashSaleProducts.map(product => (
                <Col xs={24} sm={12} md={8} lg={6} xl={4} key={product.id}>
                  <Card
                    hoverable
                    style={{
                      borderRadius: '12px',
                      overflow: 'hidden',
                      border: '1px solid #f0f0f0',
                      transition: 'all 0.3s ease',
                      cursor: 'pointer',
                      height: '100%',
                      display: 'flex',
                      flexDirection: 'column'
                    }}
                    bodyStyle={{ 
                      padding: '16px',
                      flex: 1,
                      display: 'flex',
                      flexDirection: 'column'
                    }}
                    cover={
                      <div style={{ position: 'relative', overflow: 'hidden' }}>
                        <img
                          alt={product.name}
                          src={product.image}
                          style={{ width: '100%', height: '200px', objectFit: 'cover' }}
                        />
                        <div style={{
                          position: 'absolute',
                          top: '8px',
                          left: '8px',
                          backgroundColor: '#ff4757',
                          color: 'white',
                          padding: '2px 6px',
                          borderRadius: '4px',
                          fontSize: '12px',
                          fontWeight: 'bold'
                        }}>
                          -{product.discount}%
                        </div>
                        <div style={{
                          position: 'absolute',
                          top: '8px',
                          right: '8px',
                        }}>
                          <HeartOutlined style={{ fontSize: '16px', color: 'white', backgroundColor: 'rgba(0,0,0,0.5)', padding: '4px', borderRadius: '50%' }} />
                        </div>
                      </div>
                    }
                  >
                    {/* Product content with flex-grow to push button to bottom */}
                    <div style={{ flex: 1, display: 'flex', flexDirection: 'column' }}>
                      {/* Product name - fixed height */}
                      <div style={{ marginBottom: '12px', height: '44px' }}>
                        <Text strong style={{ 
                          fontSize: '15px', 
                          lineHeight: '22px',
                          display: '-webkit-box',
                          WebkitLineClamp: 2,
                          WebkitBoxOrient: 'vertical',
                          overflow: 'hidden'
                        }}>
                          {product.name}
                        </Text>
                      </div>
                      
                      {/* Rating */}
                      <div style={{ marginBottom: '8px' }}>
                        <Rate disabled defaultValue={product.rating} style={{ fontSize: '12px' }} />
                        <Text type="secondary" style={{ fontSize: '12px', marginLeft: '4px' }}>
                          ({product.reviews})
                        </Text>
                      </div>

                      {/* Price section */}
                      <div style={{ marginBottom: '8px' }}>
                        <div style={{ display: 'flex', alignItems: 'center', gap: '8px', marginBottom: '4px' }}>
                          <Text style={{ 
                            fontSize: '18px', 
                            fontWeight: 'bold',
                            color: '#ff4757',
                            lineHeight: '1'
                          }}>
                            ${product.price}
                          </Text>
                          <Text delete style={{ 
                            fontSize: '14px', 
                            color: '#999',
                            lineHeight: '1'
                          }}>
                            ${product.originalPrice}
                          </Text>
                          <div style={{
                            background: 'linear-gradient(45deg, #ff4757, #ff3742)',
                            color: 'white',
                            padding: '2px 6px',
                            borderRadius: '4px',
                            fontSize: '11px',
                            fontWeight: 'bold'
                          }}>
                            -{product.discount}%
                          </div>
                        </div>
                        <Text style={{ fontSize: '13px', color: '#666', fontWeight: '500' }}>
                          Save ${product.originalPrice - product.price}
                        </Text>
                      </div>

                      {/* Sold count */}
                      <div style={{ fontSize: '12px', color: '#666', marginBottom: '16px', flex: 1 }}>
                        {product.sold} sold
                      </div>
                    </div>

                    {/* Button always at bottom */}
                    <Button 
                      type="primary" 
                      block 
                      size="middle"
                      icon={<ShoppingCartOutlined />}
                      style={{ 
                        background: 'linear-gradient(45deg, #ff4757, #ff3742)',
                        borderColor: 'transparent',
                        fontWeight: 'bold',
                        height: '40px',
                        borderRadius: '8px',
                        boxShadow: '0 2px 8px rgba(255, 71, 87, 0.3)',
                        marginTop: 'auto'
                      }}
                    >
                      Add to Cart
                    </Button>
                  </Card>
                </Col>
              ))}
            </Row>
          </div>
        </div>

        {/* Promotional Banners */}
        <Row gutter={[16, 16]} style={{ marginBottom: '40px' }}>
          <Col xs={24} md={12}>
            <div style={{
              background: 'linear-gradient(135deg, #667eea 0%, #764ba2 100%)',
              borderRadius: '12px',
              padding: '40px 30px',
              color: 'white',
              textAlign: 'center',
              height: '200px',
              display: 'flex',
              flexDirection: 'column',
              justifyContent: 'center'
            }}>
              <Title level={3} style={{ color: 'white', marginBottom: '8px' }}>
                Free Shipping
              </Title>
              <Paragraph style={{ color: 'white', marginBottom: '16px' }}>
                On orders over $50
              </Paragraph>
              <Button type="primary" ghost>Shop Now</Button>
            </div>
          </Col>
          <Col xs={24} md={12}>
            <div style={{
              background: 'linear-gradient(135deg, #f093fb 0%, #f5576c 100%)',
              borderRadius: '12px',
              padding: '40px 30px',
              color: 'white',
              textAlign: 'center',
              height: '200px',
              display: 'flex',
              flexDirection: 'column',
              justifyContent: 'center'
            }}>
              <Title level={3} style={{ color: 'white', marginBottom: '8px' }}>
                24/7 Support
              </Title>
              <Paragraph style={{ color: 'white', marginBottom: '16px' }}>
                Get help anytime you need
              </Paragraph>
              <Button type="primary" ghost>Contact Us</Button>
            </div>
          </Col>
        </Row>

        {/* Trust badges */}
        <div style={{ 
          backgroundColor: '#f8f9fa', 
          padding: '30px', 
          borderRadius: '12px',
          textAlign: 'center',
          marginBottom: '40px'
        }}>
          <Row gutter={[32, 16]} justify="center">
            <Col xs={12} sm={6}>
              <div>
                <div style={{ fontSize: '32px', marginBottom: '8px' }}>🚚</div>
                <Text strong>Fast Delivery</Text>
              </div>
            </Col>
            <Col xs={12} sm={6}>
              <div>
                <div style={{ fontSize: '32px', marginBottom: '8px' }}>🔒</div>
                <Text strong>Secure Payment</Text>
              </div>
            </Col>
            <Col xs={12} sm={6}>
              <div>
                <div style={{ fontSize: '32px', marginBottom: '8px' }}>↩️</div>
                <Text strong>Easy Returns</Text>
              </div>
            </Col>
            <Col xs={12} sm={6}>
              <div>
                <div style={{ fontSize: '32px', marginBottom: '8px' }}>⭐</div>
                <Text strong>Best Quality</Text>
              </div>
            </Col>
          </Row>
        </div>
      </div>
    </div>
  );
} 