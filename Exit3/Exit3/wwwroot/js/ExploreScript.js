document.addEventListener("DOMContentLoaded", function () {
    // Filtreleme seçeneklerini dinle
    document.getElementById("roomFilter").addEventListener("change", filterProducts);
    document.getElementById("artStyleFilter").addEventListener("change", filterProducts);
    document.getElementById("colorFilter").addEventListener("change", filterProducts);
});

function filterProducts() {
    // Seçilen filtreleme seçeneklerini al
    var selectedRoom = document.getElementById("roomFilter").value;
    var selectedArtStyle = document.getElementById("artStyleFilter").value;
    var selectedColor = document.getElementById("colorFilter").value;

    // Filtreleme işlemleri burada gerçekleştirilecek

    // Örnek: Filtrelenen sonuçları göster
    document.getElementById("products").innerHTML = `
      < p > Filtrelenen Sonuçlar:</ p >
      < p > Ürün 1 - ${selectedRoom}, ${selectedArtStyle}, ${selectedColor}</ p >
      < !--Diğer filtrelenen ürünleri burada listele -->
    `;
}

document.getElementById('category').addEventListener('change', function () {
    const selectedCategory = this.value;
    const products = document.querySelectorAll('.product');

    products.forEach(product => {
        const category = product.classList[1]; // Assumes each product has a category class

        if (selectedCategory === 'all' || category === selectedCategory) {
            product.style.display = 'block';
        }
        else {
            product.style.display = 'none';
        }
    });
});