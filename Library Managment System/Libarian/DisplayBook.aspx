

<%@ Page Title="" Language="C#" MasterPageFile="~/Libarian/Site1.Master" AutoEventWireup="true" CodeBehind="DisplayBook.aspx.cs" Inherits="Library_Managment_System.Libarian.DisplayBook" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cl" runat="server">
    <link href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" type="text/css" rel="stylesheet" />
    <script src ="https://code.jquery.com/jquery-3.3.1.js"></script>
    <script src="https://cdn.dataTables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    
                        <div class="card-header">
                            <strong class="card-title">Basic Table</strong>
                        </div>
                        <div class="card-body">

                            <asp:Repeater ID="r1" runat="server">

                                <HeaderTemplate>
                                    <table class="table" id="example">
                              <thead>
                                <tr>
                                  <th scope="col">Book Image</th>
                                  <th scope="col">Book Title</th>
                                  <th scope="col">Book Pdf</th>
                                  <th scope="col">Books Video</th>
                                  <th scope="col">Author Name</th>
                                  <th scope="col">ISBN</th>
                                  <th scope="col">Available Quantity</th>
                                  <th scope="col">Edit Video</th>
                                   <th scope="col">Delete Video</th>




                              </tr>
                          </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                  <tr>
                              <td><img src="<%#Eval("booksimage") %>" height="100" width="100" /></td>
                              <td><%#Eval("bookstitle") %></td>
                              <td><%#Eval("bookspdf") %><br /><%#checkpdf(Eval("bookspdf"),Eval("id"))%></td>
                              <td><%#Eval("booksvideo") %><br /><%#checkvideo(Eval("booksvideo"),Eval("id"))%></td>
                              <td><%#Eval("booksauthor")%></td>
                               <td><%#Eval("bookisbn") %></td>
                              <td><%#Eval("avaibleqty") %></td>
                              <td><a href="Editbooks.aspx?id=<%#Eval("Id")%>">Edit Books</a></td>
                              <td><a href="deletefiles.aspx?id2=<%#Eval("Id")%>">Delete Books</a></td>

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
