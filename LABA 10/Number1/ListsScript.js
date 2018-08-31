$(document).ready(function () {
    function Clear(someClass) {
        $(someClass).empty()
    }
    var leftArrJSON;
    var rightArrJSON;
    function render(someClass, someArr) {
        Clear(someClass);
        someArr.forEach(function (item) {
            $(someClass).append(`<option
      value='${item}'>${item}</option>`)
        })
    }

    function SaveCondition(leftJson,rightJson) {
        $.ajax({
            type: "POST",
            traditional: true,
            url: "/Home/SaveToLeftList", // the method we are calling
            data: { leftArray: leftJson,rightArray: rightJson },
            //success: function (result) {
            //    alert('It worked!');
            //},
            //error: function (result) {
            //    alert('Some error');
            //}
        });
    }

    function Replace(from, to, item) {
        var index = from.indexOf(item);
        if (item) {
            to.push(from[index]);
            from.splice(index, 1)
        }
    }

    function ReplaceAll(from, to) {
        for (var i = 0; i < from.length; i++) {
            to.push(from[i]);
        }
        from.splice(0)
    }


    $('.right-move').click(function (event) {
        Replace(fields_list, fields_list_second, $('.left option:selected').text());
        leftArrJSON = JSON.stringify(fields_list);
        rightArrJSON = JSON.stringify(fields_list_second)
        render(".left", fields_list);
        render(".right", fields_list_second);
        SaveCondition(leftArrJSON,rightArrJSON);
    })

    $('#left-move').click(function (event) {
        Replace(fields_list_second, fields_list, $('.right option:selected').text());
        leftArrJSON = JSON.stringify(fields_list);
        rightArrJSON = JSON.stringify(fields_list_second)
        render(".left", fields_list);
        render(".right", fields_list_second);
        SaveCondition(leftArrJSON, rightArrJSON);
    })

    $('.all-left-move').click(function (event) {
        ReplaceAll(fields_list_second, fields_list);
        leftArrJSON = JSON.stringify(fields_list);
        rightArrJSON = JSON.stringify(fields_list_second);
        render(".left", fields_list);
        render(".right", fields_list_second);
        SaveCondition(leftArrJSON, rightArrJSON);
    })

    $('.all-right-move').click(function (event) {
        ReplaceAll(fields_list, fields_list_second);
        leftArrJSON = JSON.stringify(fields_list);
        rightArrJSON = JSON.stringify(fields_list_second);
        render(".left", fields_list);
        render(".right", fields_list_second);
        SaveCondition(leftArrJSON, rightArrJSON);
    })
    render(".left", fields_list);
    render(".right", fields_list_second);
});