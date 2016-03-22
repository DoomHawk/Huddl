<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Huddl_Web._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <script>
        //Declare global JS vars
        var strTogglURL = "http://www.toggl.com/api/v8/me";
        var xhrToggl = new XMLHttpRequest();

        //Make the ajax call
        $.ajax({
            //Base parameters for every ajax call to the Toggl API
            type: 'get',
            datatype: 'json',
            contenttype: 'application/json',
            processdata: false,

            //API user authentication information
            beforesend: function (xhr) {
                xhr.setrequestheader("authorization", "basic " + btoa("f24b848ec008a3672bf694b19c3cfb98:api_token"));
            },

            //Pass the URL for the current request type
            url: strTogglURL,

            //OnSuccess actions
            success: function (data) {
                alert(json.stringify(data));
            },
            //OnError actions
            error: function () {
                alert("cannot get data");
            }
        });

        //Code Copied from Stack Overflow as example
        //var xhr = new XMLHttpRequest();
        //xhr.open("GET", "https://toggl.com/reports/api/v2/weekly?user_agent=yourname@domain.com&workspace_id=012345", false);
        //xhr.setRequestHeader('Authorization', 'Basic XXXXXX');
        //xhr.send();
        //document.write("Status code: " + xhr.status + " ");
        //document.write(xhr.statusText + "</br>");

        //curl -u "username:password" -H "Content-Type: application/json" -H "Accept: application/json" -d '{"foo":"bar"}' http://www.example.com/api

    </script>




    <div class="jumbotron">
        <h1>ASP.NET</h1>
        <p class="lead">ASP.NET is a free web framework for building great Web sites and Web applications using HTML, CSS, and JavaScript.</p>
        <p><a href="http://www.asp.net" class="btn btn-primary btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
        <div class="col-md-4">
            <h2>Getting started</h2>
            <p>
                ASP.NET Web Forms lets you build dynamic websites using a familiar drag-and-drop, event-driven model.
            A design surface and hundreds of controls and components let you rapidly build sophisticated, powerful UI-driven sites with data access.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301948">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Get more libraries</h2>
            <p>
                NuGet is a free Visual Studio extension that makes it easy to add, remove, and update libraries and tools in Visual Studio projects.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301949">Learn more &raquo;</a>
            </p>
        </div>
        <div class="col-md-4">
            <h2>Web Hosting</h2>
            <p>
                You can easily find a web hosting company that offers the right mix of features and price for your applications.
            </p>
            <p>
                <a class="btn btn-default" href="http://go.microsoft.com/fwlink/?LinkId=301950">Learn more &raquo;</a>
            </p>
        </div>
    </div>
    <asp:GridView ID="GridView1" runat="server"></asp:GridView>

</asp:Content>
