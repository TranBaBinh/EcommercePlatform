import { Link, useLocation } from 'react-router-dom';
import { Row, Col, Input, Button, Badge, Space, Dropdown, Menu } from 'antd';
import { 
  SearchOutlined, 
  ShoppingCartOutlined, 
  UserOutlined,
  BellOutlined,
  MenuOutlined,
  DownOutlined,
  HeartOutlined,
  CustomerServiceOutlined
} from '@ant-design/icons';

const { Search } = Input;

export default function Header() {
  const location = useLocation();
  
  // Giả sử user chưa login - trong thực tế sẽ check từ auth context
  const isLoggedIn = false; // Thay đổi logic này sau
  const userName = "John Doe"; // Từ auth context

  const categoryMenu = (
    <Menu
      items={[
        { key: '1', label: <Link to="/products?category=electronics">📱 Electronics</Link> },
        { key: '2', label: <Link to="/products?category=fashion">👕 Fashion</Link> },
        { key: '3', label: <Link to="/products?category=home">🏠 Home & Living</Link> },
        { key: '4', label: <Link to="/products?category=beauty">💄 Beauty</Link> },
        { key: '5', label: <Link to="/products?category=sports">⚽ Sports</Link> },
        { key: '6', label: <Link to="/products?category=books">📚 Books</Link> },
      ]}
    />
  );

  const userMenu = (
    <Menu
      items={[
        { key: '1', label: <Link to="/profile">My Account</Link> },
        { key: '2', label: <Link to="/orders">My Orders</Link> },
        { key: '3', label: <Link to="/wishlist">Wishlist</Link> },
        { key: '4', label: <Link to="/notifications">Notifications</Link> },
        { type: 'divider' },
        { key: '5', label: 'Logout' },
      ]}
    />
  );

  return (
    <div>
      {/* Top bar with contact info */}
      <div style={{ backgroundColor: '#f5f5f5', padding: '8px 0', fontSize: '12px' }}>
        <div style={{ maxWidth: 1200, margin: '0 auto', padding: '0 16px' }}>
          <Row justify="space-between" align="middle">
            <Col>
              <Space size="large">
                <span>📞 Hotline: 1900-1234</span>
                <span>📧 Support: support@eshop.com</span>
                <span>🚚 Free shipping for orders over $50</span>
              </Space>
            </Col>
            <Col>
              <Space>
                <Link to="/seller" style={{ color: '#666' }}>Become a Seller</Link>
                <Link to="/help" style={{ color: '#666' }}>Help Center</Link>
              </Space>
            </Col>
          </Row>
        </div>
      </div>

      {/* Main header */}
      <div style={{ backgroundColor: '#ee4d2d', padding: '12px 0' }}>
        <div style={{ maxWidth: 1200, margin: '0 auto', padding: '0 16px' }}>
          <Row align="middle" gutter={[16, 0]}>
            {/* Logo */}
            <Col flex="200px">
              <Link to="/" style={{ color: 'white', textDecoration: 'none' }}>
                <div style={{ fontSize: '32px', fontWeight: 'bold', display: 'flex', alignItems: 'center' }}>
                  🛒 <span style={{ marginLeft: 8 }}>E-SHOP</span>
                </div>
              </Link>
            </Col>

            {/* Search bar */}
            <Col flex="auto">
              <div style={{ position: 'relative' }}>
                <Search
                  size="large"
                  placeholder="What are you looking for today?"
                  allowClear
                  enterButton={
                    <Button 
                      type="primary" 
                      size="large" 
                      icon={<SearchOutlined />}
                      style={{ backgroundColor: '#fb5533', borderColor: '#fb5533' }}
                    >
                      Search
                    </Button>
                  }
                  style={{ width: '100%' }}
                />
                {/* Popular searches */}
                <div style={{ 
                  position: 'absolute', 
                  top: '100%', 
                  left: 0, 
                  right: 0, 
                  backgroundColor: 'white', 
                  padding: '8px 12px',
                  fontSize: '12px',
                  color: '#666',
                  display: 'none' // Show on focus
                }}>
                  Popular: iPhone 15, Samsung TV, Nike Shoes, MacBook Pro
                </div>
              </div>
            </Col>

            {/* Right actions */}
            <Col>
              <Space size="large">
                {/* Wishlist */}
                <Link to="/wishlist">
                  <Badge count={5} size="small">
                    <Button 
                      type="text" 
                      icon={<HeartOutlined />} 
                      style={{ color: 'white', fontSize: '20px' }}
                    />
                  </Badge>
                </Link>

                {/* Cart */}
                <Link to="/cart">
                  <Badge count={3} size="small">
                    <Button 
                      type="text" 
                      icon={<ShoppingCartOutlined />} 
                      style={{ color: 'white', fontSize: '20px' }}
                    />
                  </Badge>
                </Link>

                {/* User menu - Conditional rendering based on login status */}
                {isLoggedIn ? (
                  <Dropdown overlay={userMenu} trigger={['click']}>
                    <Button 
                      type="text" 
                      style={{ color: 'white', padding: '0 8px' }}
                    >
                      <UserOutlined style={{ fontSize: '18px', marginRight: 4 }} />
                      {userName} <DownOutlined />
                    </Button>
                  </Dropdown>
                ) : (
                  <Space>
                    <Link to="/login">
                      <Button 
                        type="text" 
                        style={{ color: 'white', fontWeight: 500 }}
                      >
                        Login
                      </Button>
                    </Link>
                    <Link to="/register">
                      <Button 
                        type="primary" 
                        size="small"
                        style={{ 
                          backgroundColor: '#fb5533', 
                          borderColor: '#fb5533',
                          fontWeight: 500 
                        }}
                      >
                        Sign Up
                      </Button>
                    </Link>
                  </Space>
                )}
              </Space>
            </Col>
          </Row>
        </div>
      </div>

      {/* Navigation bar */}
      <div style={{ backgroundColor: 'white', borderBottom: '1px solid #e8e8e8', padding: '8px 0' }}>
        <div style={{ maxWidth: 1200, margin: '0 auto', padding: '0 16px' }}>
          <Row justify="space-between" align="middle">
            <Col>
              <Space size="large">
                <Dropdown overlay={categoryMenu} trigger={['hover']}>
                  <Button type="text" icon={<MenuOutlined />}>
                    Categories <DownOutlined />
                  </Button>
                </Dropdown>
                
                <Space size="middle">
                  <Link to="/" style={{ color: location.pathname === '/' ? '#ee4d2d' : '#333' }}>
                    Home
                  </Link>
                  <Link to="/products" style={{ color: location.pathname === '/products' ? '#ee4d2d' : '#333' }}>
                    All Products
                  </Link>
                  <Link to="/deals" style={{ color: '#333' }}>
                    🔥 Flash Sale
                  </Link>
                  <Link to="/brands" style={{ color: '#333' }}>
                    Brands
                  </Link>
                  <Link to="/new-arrivals" style={{ color: '#333' }}>
                    New Arrivals
                  </Link>
                </Space>
              </Space>
            </Col>
            
            <Col>
              <Space>
                <Button type="text" icon={<CustomerServiceOutlined />} style={{ color: '#666' }}>
                  Live Chat
                </Button>
                <Button type="text" icon={<BellOutlined />} style={{ color: '#666' }}>
                  Notifications
                </Button>
              </Space>
            </Col>
          </Row>
        </div>
      </div>
    </div>
  );
}