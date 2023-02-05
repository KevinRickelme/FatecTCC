
    $(
        function animateProfileInfo() {
            $(document).click(function () {
                if ($('.btn-profile-pic').hasClass('show')) {
                    $('.divProfile').addClass('removeBordaMenu');
                }
                else {
                    $('.divProfile').removeClass('removeBordaMenu');
                    $('.divProfile').addClass('adicionaBordaMenu');
                }
            });
        });
