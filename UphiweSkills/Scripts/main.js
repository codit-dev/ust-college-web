var map;
$(document).ready(function () {

    /* ======= Flexslider ======= */
    $('.flexslider').flexslider({
        animation: "fade"
    });

    /* ======= jQuery Placeholder ======= */
    $('input, textarea').placeholder();

    /* ======= Carousels ======= */
    $('#news-carousel').carousel({ interval: false });
    $('#videos-carousel').carousel({ interval: false });
    $('#testimonials-carousel').carousel({ interval: 6000, pause: "hover" });
    $('#awards-carousel').carousel({ interval: false });


    /* ======= Flickr PhotoStream ======= */

    $('#flickr-photos').jflickrfeed({
        limit: 12,
        qstrings: {
            id: '138784770@N07' /* Use idGettr.com to find the flickr user id */
        },
        itemTemplate:
            '<li>' +
            '<a href="{{image}}" title="{{title}}" target="_blank">' +
            	'<img src="{{image_s}}" alt="{{title}}" />' +
            '</a>' +
            '</li>'

    });

    /* Nested Sub-Menus mobile fix */

    $('li.dropdown-submenu > a.trigger').on('click', function (e) {
        var current = $(this).next();
        current.toggle();
        e.stopPropagation();
        e.preventDefault();
        if (current.is(':visible')) {
            $(this).closest('li.dropdown-submenu').siblings().find('ul.dropdown-menu').hide();
        }
    });

    /* ======= Pretty Photo ======= */
    // http://www.no-margin-for-errors.com/projects/prettyphoto-jquery-lightbox-clone/ 
    $('a.prettyphoto').prettyPhoto();

    /* ======= FAQ accordion ======= */
    $('.card-toggle').on('click', function () {
        if ($(this).find('svg').attr('data-icon') == 'plus-square') {
            $(this).find('svg').attr('data-icon', 'minus-square');
        } else {
            $(this).find('svg').attr('data-icon', 'plus-square');
        };
    });

    /* ======= Bootstrap Image Uploader ======= */

    $(document).on('click', '#close-preview', function () {
        $('.image-preview').popover('hide');
        // Hover befor close the preview
        $('.image-preview').hover(
            function () {
                $('.image-preview').popover('show');
            },
             function () {
                 $('.image-preview').popover('hide');
             }
        );
    });

    $(function () {
        // Create the close button
        var closebtn = $('<button/>', {
            type: "button",
            text: 'x',
            id: 'close-preview',
            style: 'font-size: initial;',
        });
        closebtn.attr("class", "close pull-right");
        // Set the popover default content
        $('.image-preview').popover({
            trigger: 'manual',
            html: true,
            title: "<strong>Preview</strong>" + $(closebtn)[0].outerHTML,
            content: "There's no image",
            placement: 'bottom'
        });
        // Clear event
        $('.image-preview-clear').click(function () {
            $('.image-preview').attr("data-content", "").popover('hide');
            $('.image-preview-filename').val("");
            $('.image-preview-clear').hide();
            $('.image-preview-input input:file').val("");
            $(".image-preview-input-title").text("Browse");
        });
        // Create the preview image
        $(".image-preview-input input:file").change(function () {
            var img = $('<img/>', {
                id: 'dynamic',
                width: 250,
                height: 200
            });
            var file = this.files[0];
            var reader = new FileReader();
            // Set preview image into the popover data-content
            reader.onload = function (e) {
                $(".image-preview-input-title").text("Change");
                $(".image-preview-clear").show();
                $(".image-preview-filename").val(file.name);
                img.attr('src', e.target.result);
                $(".image-preview").attr("data-content", $(img)[0].outerHTML).popover("show");
            }
            reader.readAsDataURL(file);
        });
    });


});
