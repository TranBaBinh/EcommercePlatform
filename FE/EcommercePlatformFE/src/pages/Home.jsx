export default function Home() {
  // New Arrivals Products
  const newArrivals = [
    {
      id: 1,
      name: "The Velvet Blazer",
      price: 1250,
      category: "Tailored Fit",
      image: "https://lh3.googleusercontent.com/aida-public/AB6AXuCpGu9TbcfxXRAxQ0EH8VA2COZmCEgUpfUGkOyoqYRXhXSjQEdhnPthwCsiKCp0HiQV_n3srR53U305PxMW9iovkjJ1RabsJrPpuWnozF3xtxVFVQ70CRw927gk8atDZ0Yvm1epruG0XojFBrbyMqdjDyVqMxXdsp8I7pDMXynXpTGjeotGm5lXExcq1KdNHA4vG9qOPSrkC-rnnqR50N0KL77D1cjGbwgsLkRy0eL-Fv_uTSiMPqu55GmG9QpCT-c5hT4_7B-jZyq9",
      isNew: true
    },
    {
      id: 2,
      name: "Silk Evening Gown",
      price: 2800,
      category: "Noir Collection",
      image: "https://lh3.googleusercontent.com/aida-public/AB6AXuCr3tGj7depA8v9vt_b9LsHJnZ1RkOU3Jz25sCWXbqLUfh0ZN2uRXERR519PvsyvAEFTCY61YSY5r0nBEtz66SIszdmsP3B3OT3ti9Wgq4CnUERGBlc4OJ-fmaIH1pdaUfBngncxgf-0Bo26IXiM9h4SlPxTTH2ExbaARRyv6V8Qe73XhonGDW9Lmg4ORJc03WnvBlARbiLOKz5Cs1gVJJcb3TlgwHDS1WRlcfRqI8JSPTsrjV-GiazbTpfpEsWZ-lnMf1LeYmHrSrD",
      isNew: false
    },
    {
      id: 3,
      name: "Obsidian Tote",
      price: 890,
      category: "Italian Leather",
      image: "https://lh3.googleusercontent.com/aida-public/AB6AXuBy5a3plkkcGfUO-ylYJtBQUtJvntYPVA68JGqfNeKqe9ye6bC6hw4ojznwI-ALTDkmp60FuDeXPYP8ZUDJWoEtdvK0mrMYmPVYSDSqlzFGLYQV8Oo9pJh5-akRBVfgNKkJALLWPhCHUx4aMESikGY3gV5c-THfPynjLXgJcrl-d9TuxbS6cF3tLUU8qJhjbeJEYo_Oz7MclnkRxukAMSuHgcB6YpKzT1KlnNHk0VKTQd9EPOsqLVugr3JTVeOrmcsCWUmtfvyQn2JE",
      isNew: false
    }
  ];

  // Curated Collections
  const collections = [
    {
      id: 1,
      title: "Urban Noir",
      image: "https://lh3.googleusercontent.com/aida-public/AB6AXuAq0khqLWx6DHUPhibSnsd5lFAEFd-TOJgAicgwLbjXNEW_pZh_qTCTvECN2nd8x6AkdAlf69EGS2JfMek0pt4w0-z33iGZ9c5mwtVrF_6APOnUDYJO9_aYzxhV82d-X_SC9qIx3Enoou21OT7KKzgnRuM0wIVMr-stcB4pxcTPW48wQZmLHeeeUCYcDWcUcmfNFt0Zkcf4D0cO1z_WNUdHxztSX67UzKwPJqwx7e7nKfeVZWGXeTEZnE6PRWBN403e_pOQRFVaqYOG",
      size: "large"
    },
    {
      id: 2,
      title: "Gold & Glare",
      subtitle: "Accessories",
      image: "https://lh3.googleusercontent.com/aida-public/AB6AXuCU_sUeO9HP2eqOWbR9QzAD2En4xHz0FDPBkZ-DP-kgXDG6bjCHZDOhasSZ3twzE96mEAiBPWB46ro9GmTLzwzU-nouTrX9PM_KbJ9GNOTFTJDdHJM_jDCt-b0elFFY0P6AUKawXoAWlLoVkbqtbRJRAnJnTMl1S4xmVHFbIOC5SfNmyMEiMhnMPA6Vg3c7rj9web7B8-zJS9ST2awvScKTvx1v0yMGQ8-KcaOd7w6NLPLLg2PyxlBhiKNIgPEUGvFVBlVac4AO0iPW",
      size: "small"
    },
    {
      id: 3,
      title: "Modern Gent",
      subtitle: "Men's Edit",
      image: "https://lh3.googleusercontent.com/aida-public/AB6AXuCAgrxyoYayzCx-BNSWsiT12mA79M2KKhm6QuGPGJkBsjD17J9_3ZNqzQxp0qtLnntIq-xQmnGwha_3qnuV9W2-RgzgQGxBa_86uTIDjgzhmmbpEQIUP2nyXcdr9VJcD5ElmJb0J3SOeKuuLaqwOYZrVlIEHoQDvva-oXFfZ4fvEy4bRksKtYJBdxnWmjUWFId9QbcQsnL1SpFQlE98ClAjq3TgZSI92q7nJBkWqBvPoL72L0F8C-Vtr3NRTT9xUZZulkOk5hiqkzk_",
      size: "small"
    },
    {
      id: 4,
      title: "The Editorial",
      image: "https://lh3.googleusercontent.com/aida-public/AB6AXuDOWIyM3ML2yQcvqqOpPwRNagjz1BCEpLsPalUBbx5vbFfizv2PBoEZsxjIi0SPvrbv48Uy7J5FJLxrA1nqXXDQXe6CZf70pGyF9NX3iff0Qu2H8b0DzaqiLAdFEihPoqvaSqwKEeYdQ9j1hfpK6RsQ8evwRYaYAf0Nr2JJPV1PzY-aeUsww5bP5_LpmlDMl5byfxaR0hObyKb2EiqiU_u7g9ZMKwVptSt6oA7mzYXLYUq6Wrp9ErkwqugnPK3P8bmfz1J-aO5Esaor",
      size: "banner"
    }
  ];

  return (
    <div className="bg-[#0f0f0f] text-white">
      {/* Hero Section */}
      <section className="relative h-[90vh] min-h-[600px] w-full overflow-hidden">
        {/* Background Image with Overlay */}
        <div 
          className="absolute inset-0 bg-cover bg-center bg-no-repeat"
          style={{
            backgroundImage: 'url("https://lh3.googleusercontent.com/aida-public/AB6AXuAFaSo-S2Abj4h7MZQg9hpL_amTZqdoPlBwsz7WJQoXeRs3aihG5ngEtGQgMiJhg4Q3IlLnePis__KVP1lC85QfmWibo4PMK4ILiXjFGrglTRNzirBbHBNnNj0vBAp_vnTPt14GoFMuEVOmocHss5Xaa6otu1NbSfjQtKCaO1LHHoIVb_jA80m0I8zSa9xw-WNPghjPcNKzJw3O6uZ2GGF75ufEUyZw2rIWXbfdGdGqTG-UJfIxGj_0YMl8Lskxa05Kf-ZHJgM4IfGm")'
          }}
        >
          <div className="absolute inset-0 bg-gradient-to-b from-black/40 via-transparent to-[#0f0f0f]"></div>
          <div className="absolute inset-0 bg-black/20"></div>
        </div>

        {/* Hero Content */}
        <div className="relative h-full flex flex-col justify-end pb-20 px-6 lg:px-20 max-w-[1400px] mx-auto">
          <div className="max-w-3xl">
            <p className="text-white/80 text-sm font-bold tracking-[0.2em] uppercase mb-4 pl-1">
              Autumn / Winter 2024
            </p>
            <h2 className="text-white text-5xl md:text-7xl lg:text-8xl font-serif font-medium leading-[1.1] tracking-tight mb-8">
              Redefining <br />
              <span className="italic font-light">Silhouette</span>
            </h2>
            <button className="group flex items-center gap-3 bg-[#f20d33] hover:bg-red-700 text-white px-8 py-4 rounded text-sm font-bold tracking-widest uppercase transition-all duration-300 transform hover:translate-x-1">
              Shop Collection
              <span className="material-symbols-outlined text-sm transition-transform group-hover:translate-x-1">
                arrow_forward
              </span>
            </button>
          </div>
        </div>
      </section>

      {/* New Arrivals Section */}
      <section className="px-6 py-20 lg:px-12 bg-[#0f0f0f]">
        <div className="max-w-[1400px] mx-auto">
          <div className="flex items-end justify-between mb-10">
            <h3 className="text-3xl text-white font-serif italic font-normal">New Arrivals</h3>
            <a 
              href="#" 
              className="text-sm font-bold text-white/60 hover:text-white uppercase tracking-widest border-b border-transparent hover:border-[#f20d33] pb-1 transition-all"
            >
              View All
            </a>
          </div>

          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-3 gap-8">
            {newArrivals.map((product) => (
              <div key={product.id} className="group relative flex flex-col gap-4">
                <div className="relative aspect-[3/4] w-full overflow-hidden rounded bg-[#181818]">
                  <div 
                    className="absolute inset-0 bg-cover bg-center transition-transform duration-700 group-hover:scale-105"
                    style={{ backgroundImage: `url("${product.image}")` }}
                  ></div>
                  
                  <div className="absolute bottom-4 right-4 translate-y-full opacity-0 transition-all duration-300 group-hover:translate-y-0 group-hover:opacity-100">
                    <button className="bg-white text-black p-3 rounded-full hover:bg-[#f20d33] hover:text-white transition-colors shadow-lg">
                      <span className="material-symbols-outlined block">add_shopping_cart</span>
                    </button>
                  </div>
                  
                  {product.isNew && (
                    <span className="absolute top-4 left-4 bg-[#f20d33] text-white text-[10px] font-bold px-2 py-1 rounded uppercase tracking-wider">
                      New
                    </span>
                  )}
                </div>
                
                <div className="flex flex-col gap-1">
                  <div className="flex justify-between items-start">
                    <h4 className="text-white text-lg font-medium">{product.name}</h4>
                    <p className="text-white/70 font-display">${product.price.toLocaleString()}</p>
                  </div>
                  <p className="text-white/40 text-sm">{product.category}</p>
                </div>
              </div>
            ))}
          </div>
        </div>
      </section>

      {/* Curated Collections Grid */}
      <section className="px-6 pb-20 lg:px-12 bg-[#0f0f0f]">
        <div className="max-w-[1400px] mx-auto">
          <h3 className="text-3xl text-white font-serif italic font-normal mb-10">Curated Collections</h3>
          
          <div className="grid grid-cols-1 md:grid-cols-2 lg:grid-cols-4 gap-4 h-auto lg:h-[600px]">
            {/* Large Item - Urban Noir */}
            <div className="group relative col-span-1 md:col-span-2 lg:col-span-2 row-span-2 overflow-hidden rounded">
              <div 
                className="absolute inset-0 bg-cover bg-center transition-transform duration-1000 group-hover:scale-105"
                style={{ backgroundImage: `url("${collections[0].image}")` }}
              ></div>
              <div className="absolute inset-0 bg-black/30 group-hover:bg-black/40 transition-colors"></div>
              <div className="absolute bottom-8 left-8">
                <h4 className="text-white text-3xl font-serif italic mb-2">{collections[0].title}</h4>
                <a 
                  href="#" 
                  className="text-white/80 hover:text-[#f20d33] text-sm font-bold uppercase tracking-widest transition-colors flex items-center gap-2"
                >
                  Explore <span className="material-symbols-outlined text-sm">arrow_forward</span>
                </a>
              </div>
            </div>

            {/* Stacked Small Items */}
            {collections.slice(1, 3).map((collection) => (
              <div key={collection.id} className="group relative col-span-1 md:col-span-1 lg:col-span-1 row-span-1 h-[300px] lg:h-auto overflow-hidden rounded">
                <div 
                  className="absolute inset-0 bg-cover bg-center transition-transform duration-1000 group-hover:scale-105"
                  style={{ backgroundImage: `url("${collection.image}")` }}
                ></div>
                <div className="absolute inset-0 bg-black/20 group-hover:bg-black/30 transition-colors"></div>
                <div className="absolute bottom-6 left-6">
                  <h4 className="text-white text-xl font-medium mb-1">{collection.title}</h4>
                  <span className="text-white/60 text-xs uppercase tracking-wider">{collection.subtitle}</span>
                </div>
              </div>
            ))}

            {/* Banner - The Editorial */}
            <div className="group relative col-span-1 md:col-span-2 lg:col-span-4 row-span-1 h-[250px] overflow-hidden rounded">
              <div 
                className="absolute inset-0 bg-cover bg-center bg-fixed"
                style={{ backgroundImage: `url("${collections[3].image}")` }}
              ></div>
              <div className="absolute inset-0 bg-black/60 flex items-center justify-center">
                <div className="text-center">
                  <h4 className="text-white text-3xl font-serif italic mb-4">{collections[3].title}</h4>
                  <button className="text-white border border-white px-6 py-2 rounded uppercase text-xs font-bold hover:bg-white hover:text-black transition-all">
                    Read Stories
                  </button>
                </div>
              </div>
            </div>
          </div>
        </div>
      </section>

      {/* Brand Story */}
      <section className="flex flex-col md:flex-row w-full bg-[#181818]">
        <div className="w-full md:w-1/2 min-h-[500px] relative">
          <div 
            className="absolute inset-0 bg-cover bg-center"
            style={{
              backgroundImage: 'url("https://lh3.googleusercontent.com/aida-public/AB6AXuAghjXR9uYiBrSR6o93cwKkA7GFyr3kMDT3pkpGzMcQ6y14OMV4OkkU7ICH0uhLm79F2MXFfnB_F5vpkGZgyBvEOVzOI_BtPbBZQc57ERkSJetnGCfqOVXmZiQwT_HDiJ6E2lCZYHqDUiljyLLrbzxCwWShhyCbfez0HnT50yZzLFFSF10ekSS-NCd4mfewT0R0NP1uc_K5yCbSMVVmzHJqMSK_NOov4PaGL_kfoPfncl8Pm0peYnHcbs04cZDyk8iXm2sEu5uiatiM")'
            }}
          ></div>
        </div>
        <div className="w-full md:w-1/2 flex flex-col justify-center px-8 py-20 md:px-20 lg:px-32">
          <span className="text-[#f20d33] font-bold uppercase tracking-widest text-xs mb-4">Heritage</span>
          <h2 className="text-white text-4xl lg:text-5xl font-serif italic mb-6">Crafted for Eternity</h2>
          <p className="text-white/70 leading-relaxed text-lg mb-8 font-light">
            We believe in the quiet power of understated luxury. Each piece is meticulously designed in our Paris atelier, using only the finest ethically sourced materials. Our collection is not just about fashion; it's about a lifestyle of elegance, resilience, and timeless beauty.
          </p>
          <a 
            href="#" 
            className="text-white font-bold border-b border-white/30 pb-1 self-start hover:text-[#f20d33] hover:border-[#f20d33] transition-colors"
          >
            Discover Our Story
          </a>
        </div>
      </section>
    </div>
  );
}