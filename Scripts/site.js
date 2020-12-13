$(document).ready(function () {

    //when page loads
    $('#heading-list').html('');
    $('#wiki-search-text').val('');
    $('#wiki-result-headings').hide();
    $('#progress').html('');


    //when search btn click
    $('#wiki-search-btn').on('click', function () {

        var searchText = $('#wiki-search-text').val();

        $('#heading-list').html('');
        $('#wiki-result-headings').hide();

        if (searchText != "") {
            $('#progress').html('Please Wait...');

            $.getJSON("https://en.wikipedia.org/w/api.php?action=query&format=json&gsrlimit=20&generator=search&origin=*&gsrsearch=" + searchText, function (data) {
                //console.log(data.query.pages);
                $('#progress').html('');

                SavedInDatabase(searchText);

                $('#wiki-result-headings').show();
                var pageList = data.query.pages;
                $.each(pageList, function (idx, value) {
                    $('#heading-list').append('<li><a href="http://en.wikipedia.org/wiki/' + encodeURIComponent(value.title) + '">' + value.title + '</a></li>')
                });

            });
        }
        else {
            $('#wiki-result-headings').hide();
        }
    });

    //for checking whether input is empty(to remove search results)
    $('#wiki-search-text').on('keyup', function () {
        if ($('#wiki-search-text').val() == "") {
            $('#wiki-result-headings').hide();
            $('#heading-list').html('');
        }
    });

    //function to save item in database
    function SavedInDatabase(SearchText) {
        $.ajax({
            url: "/Wiki/SavedSearchItem?SearchItem=" + SearchText,
            method: "POST",
            success: function (data) {
                console.log(data);
            }
        })
    }
});