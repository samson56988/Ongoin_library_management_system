<%@ Page Title="" Language="C#" MasterPageFile="~/Libarian/Site1.Master" AutoEventWireup="true" CodeBehind="DisplayStudent.aspx.cs" Inherits="Library_Managment_System.Student.DisplayStudent" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cl" runat="server">
     <link href="https://cdn.datatables.net/1.10.19/css/jquery.dataTables.min.css" type="text/css" rel="stylesheet" />
    <script src ="https://code.jquery.com/jquery-3.3.1.js"></script>
    <script src="https://cdn.dataTables.net/1.10.19/js/jquery.dataTables.min.js"></script>
    
    <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-title">Student List</strong>
                        </div>
                        <div class="card-body">

                            <asp:Repeater ID="r1" runat="server">

                                <HeaderTemplate>
                                    <table class="table table-bordered" id="example">
                              <thead>
                                <tr>
                                 <%--// <th scope="col">Image</th>--%>
                                  <th scope="col">First Name</th>
                                  <th scope="col">Last Name</th>
                                  <th scope="col">Enrollment No</th>
                                  <th scope="col">Username</th>
                                  <th scope="col">Email</th>
                                  <th scope="col">Contact</th>
                                  <th scope="col">Status</th>
                                  <th scope="col">Activate</th>
                                  <th scope="col">Deactivate</th>
                                  




                              </tr>
                          </thead>
                                        <tbody>
                                </HeaderTemplate>
                                <ItemTemplate>
                                  <tr>
                             <%-- <td><img src="<%#Eval("studentimage") %>" height="100" width="100" /></td>--%>
                              <td><%#Eval("Firstname") %></td>
                              <td><%#Eval("Lastname") %></td>
                              <td><%#Eval("enrollmentno") %></td>
                              <td><%#Eval("username")%></td>
                              <td><%#Eval("email") %></td>
                              <td><%#Eval("contact") %></td>
                              <td><%#Eval("status") %></td>
                              <td><a href="studentactivate.aspx?id=<%#Eval("id")%>">Active</a></td>
                              <td><a href="studentdeactivate.aspx?id=<%#Eval("id")%>">Deactivate</a></td>
                  
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
            
       <script type="text/javascript">

        $(document).ready(function () {

            $('#example').DataTable({

                "pagingType": "full_numbers"

            });
        });

    </script>            
                      
</asp:Content>
