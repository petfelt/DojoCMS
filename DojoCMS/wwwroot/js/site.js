// Write your Javascript code.
$(document).ready(function() {
    $("#submit_changes").submit(function(e){
        e.preventDefault();
        var returner = $("#allData").html();
        console.log($("#allData").html());
        //
        // Old build of dictionary <string, dictionary <string, objects>> to pass back.
        // var returner = {};
        // returner["navBar"] = {};
        // returner["sideBar"] = {};
        // returner["mainBody"] = {};
        // returner["navBar"]["attributes"] = ["class = \"navbar navbar-inverse\""];
        // returner["navBar"]["tag"] = "div";
        // returner["navBar"]["links"] = ["WebSitePage","Home","Page 1","Page 2","Page 3"];
        // returner["sideBar"]["attributes"] = ["class = \"col-sm-2 sidebar1\""]
        // returner["sideBar"]["tag"] = "div";
        // returner["sideBar"]["links"] = ["Home","Page 1","Page 2","Page 3"];
        // returner["mainBody"]["attributes"] = ["class = \"col-sm-9 col-sm-offset-2\""]
        // returner["mainBody"]["tag"] = "div";
        // returner["mainBody"]["title"] = "Post Title";
        // returner["mainBody"]["PostMessage"] = "Edit your post text here.";
        // returner["mainBody"]["userName"] = "%userName%";
        // returner["mainBody"]["createdDate"] = "%created_at%";

        // NEED TO ADD ALL EDITABLE FIELDS, ONES NOT IN THE SKELETON.



        $.post( "test.php", { returner }, function( data ) {
            console.log( data ); // Return data
        }, "json");
    });
});