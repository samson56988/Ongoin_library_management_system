<%@ Page Title="" Language="C#" MasterPageFile="~/Libarian/Site1.Master" AutoEventWireup="true" CodeBehind="Issuebooks.aspx.cs" Inherits="Library_Managment_System.Libarian.Issuebooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cl" runat="server">

     <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-title">Issued Books</strong>
                        </div>
                        <div class="card-body">
                          <!-- Credit Card -->
                          <div id="pay-invoice">
                               <div class="card-body">
                                  <div class="card-title">
                                      <h3 class="text-center">Book Details</h3>
                                  </div>
                                  <hr>
                                  <form  runat="server" method="post" novalidate="novalidate">
                                     <div class="alert alert-success"  id="msg3" runat="server" style="margin-top:10px; display:none">
                           <strong>This book is already available with student </strong>
                                      </div>
                                      <div class="form-group">
                                          <label for="cc-payment" class="control-label mb-1">Select enrollment no</label>
                                          <asp:DropDownList ID="enronoDROP" runat="server" CssClass="form-control"></asp:DropDownList>

                                      </div>
                                       <div class="form-group">
                                           <div class="alert alert-success"  id="msg4" runat="server" style="margin-top:10px; display:none">
                                        <strong>Please Select Books </strong>
                                      </div>
                                          <label for="cc-payment" class="control-label mb-1">Books ISBN</label>
                                              <asp:DropDownList ID="ISBNDROP" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ISBNDROP_SelectedIndexChanged">
                                                  <asp:ListItem></asp:ListItem>
                                           </asp:DropDownList>
                                         
                                      </div>
                                       <div class="form-group">
                                           <asp:Image ID="i1" runat="server" Height="150" Width="150" /><br />

                                           <asp:Label ID="booksname" runat="server"></asp:Label><br />

                                           <asp:Label ID="instock" runat="server"></asp:Label><br />

                                           
                                      </div>
                                      
                                       
                                     
                                     
                                      
                                      <div>
                                         

                                         <asp:Button ID="btnissuebook" class="btn btn-lg btn-info btn-block"  runat="server" Text="Issue Book" OnClick="btnissuebook_Click" />
                                      </div>
                             <div class="alert alert-success"  id="msg2" runat="server" style="margin-top:10px; display:none">
                           <strong>This Book is not available in stock </strong>
                             </div>
                                      <div class="alert alert-success"  id="msg" runat="server" style="margin-top:10px; display:none">
                           <strong>Book Issued Successfully </strong>
                                      </div>
                                        
                                  </form>
                              </div>
                          </div>

                        </div>
                    </div> <!-- .card -->

                  </div>

</asp:Content>
