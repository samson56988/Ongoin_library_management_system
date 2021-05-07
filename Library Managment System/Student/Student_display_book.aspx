<%@ Page Title="" Language="C#" MasterPageFile="~/Student/Student.Master" AutoEventWireup="true" CodeBehind="Student_display_book.aspx.cs" Inherits="Library_Managment_System.Student_display_book" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cl" runat="server">


    <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-title">Basic Table</strong>
                        </div>
                        <div class="card-body">

                            <asp:Repeater ID="r1" runat="server">

                                <HeaderTemplate>
                                    <table class="table">
                              <thead>
                                <tr>
                                  <th scope="col">Book Image</th>
                                  <th scope="col">Book Title</th>
                                  <th scope="col">Book Pdf</th>
                                  <th scope="col">Books Video</th>
                                  <th scope="col">Author Name</th>
                                  <th scope="col">ISBN</th>
                                  <th scope="col">Available Quantity</th>
                                  




                              </tr>
                          </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                  <tr>
                                      
                              <td><img src=" ../Libarian/<%#Eval("booksimage") %>" height="100" width="100" /></td>
                              <td><%#Eval("bookstitle") %></td>
                              <td><%#Eval("bookspdf") %><br /><%#checkpdf(Eval("bookspdf"),Eval("id"))%></td>
                              <td><%#Eval("booksvideo") %><br /><%#checkvideo(Eval("booksvideo"),Eval("id"))%></td>
                              <td><%#Eval("booksauthor")%></td>
                               <td><%#Eval("bookisbn") %></td>
                              <td><%#Eval("avaibleqty") %></td>
                              

                                 </tr>
                                </ItemTemplate>
                                <FooterTemplate>
                                    </tbody>
                                   </table>

                                </FooterTemplate>


                            </asp:Repeater>
                            
                         
                           
                         
                      
                        </div>
                    </div>
                </div>



</asp:Content>
