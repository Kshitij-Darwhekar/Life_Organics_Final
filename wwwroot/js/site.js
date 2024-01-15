$('.like-btn').on('click', function () {
    $(this).toggleClass('is-active');
});

$('.minus-btn').on('click', function (e) {
    e.preventDefault();
    var $this = $(this);
    var $input = $this.closest('div').find('input');
    var value = parseInt($input.val());

    if (value > 1) {
        value = value - 1;
    } else {
        value = 0;
    }

    $input.val(value);
});

$('.plus-btn').on('click', function (e) {
    e.preventDefault();
    var $this = $(this);
    var $input = $this.closest('div').find('input');
    var value = parseInt($input.val());

if (value < 100) {
     value = value + 1;
} else {
     value = 100;
 }

    $input.val(value);
});


   /* function addToCart(productId) {
            $.ajax({
                url: '/Cart/AddToCart',
                type: 'POST',
                data: { productId: productId },
                success: function (result) {
                    if (result.success) {
                        // Optionally, you can show a success message to the user
                        alert(result.message);
                    } else {
                        // Handle error if necessary
                        alert('Failed to add product to cart.');
                    }
                },
                error: function () {
                    // Handle error if necessary
                    alert('Failed to add product to cart.');
                }
            });
        }
*/