<%@ Page Title="" Language="C#" MasterPageFile="~/Libarian/Site1.Master" AutoEventWireup="true" CodeBehind="return_books.aspx.cs" Inherits="Library_Managment_System.Libarian.return_books" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cl" runat="server">
   
    
     <link href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" type="text/css" rel="stylesheet" />
    <script src ="https://code.jquery.com/jquery-3.3.1.js"></script>
    <script src="https://cdn.dataTables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    
     
    <div class="container-fluid" style="min-height:500px; background-color:white">
        
        <div class="breadcrumbs">
            <div class="col-sm-4">
                <div class="page-header float-left">
                    <div class="page-title">
                        <h1>Return Books</h1>
                    </div>
                </div>
            </div>
            
        </div>
       <asp:Repeater ID="d1" runat="server">
            <HeaderTemplate>

                <table class="table table-bordered" id="example">
                    <thead>
                    <tr>

                        <th>Student Enrollment No</th>
                        <th>Student ISBN</th>
                        <th>Student Issue Date</th>
                        <th>Book Appromimation Return Date</th>
                        <th>Student Username</th>
                        <th>Is Book Return</th>
                        <th>Book Return Date</th>
                        <th>Latedays</th>
                        <th>Penalty</th>
                        <th>Return Books</th>
                     
                    </tr>
                   </thead>

               
                    <tbody>

            </HeaderTemplate>

            <ItemTemplate>
                   
                
                <tr>

                     <td><%#Eval("studentenrollment")%></td>
                     <td><%#Eval("bookisbn")%></td>
                     <td><%#Eval("bookissuedate")%></td>
                     <td><%#Eval("bookapproxreturndate")%></td>
                     <td><%#Eval("studentusername")%></td>
                     <td><%#Eval("isbookreturn")%></td>
                     <td><%#Eval("bookreturndate")%></td>
                    <td><%#Eval("latedays")%></td>
                    <td><%#Eval("Penalty")%></td>
                     <td><a href="returnbook.aspx?id=<%#Eval("id") %>">Return Books</a></td>

                 </tr>
                

            </ItemTemplate>

            <FooterTemplate>
                </tbody>
                 </table>
            </FooterTemplate>
             

        </asp:Repeater>
                            

    </div>
            
          <script type="text/javascript">

        $(document).ready(function () {

            $('#example').DataTable({

                "pagingType": "full_numbers"

            });
        });

    </script>  


</asp:Content>
