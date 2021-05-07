<%@ Page Title="" Language="C#" MasterPageFile="~/Libarian/Site1.Master" AutoEventWireup="true" CodeBehind="Addbooks.aspx.cs" Inherits="Library_Managment_System.Libarian.Addbooks" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cl" runat="server">
    <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-title">Add New Books</strong>
                        </div>
                        <div class="card-body">
                          <!-- Credit Card -->
                          <div id="pay-invoice">
                               <div class="card-body">
                                  <div class="card-title">
                                      <h3 class="text-center">Book Details</h3>
                                  </div>
                                  <hr>
                                  <form action="" runat="server" method="post" novalidate="novalidate">
                                     
                                      <div class="form-group">
                                          <label for="cc-payment" class="control-label mb-1">Book Title</label>
                                          <asp:TextBox ID="Booktitle" runat="server" CssClass="form-control"></asp:TextBox>
                                      </div>
                                       <div class="form-group">
                                          <label for="cc-payment" class="control-label mb-1">Book Image</label>
                                          <asp:FileUpload ID="F1" runat="server" CssClass="form-control" />
                                      </div>
                                       <div class="form-group">
                                          <label for="cc-payment" class="control-label mb-1">Book Pdf</label>
                                          <asp:FileUpload ID="F2" runat="server" CssClass="form-control" />
                                      </div>
                                      <div class="form-group">
                                          <label for="cc-payment" class="control-label mb-1">Book Video</label>
                                          <asp:FileUpload ID="F3" runat="server" CssClass="form-control" />
                                      </div>
                                       <div class="form-group">
                                          <label for="cc-payment" class="control-label mb-1">Book Author Name</label>
                                          <asp:TextBox ID="Bookauthor" runat="server" CssClass="form-control"></asp:TextBox>
                                      </div>
                                       <div class="form-group">
                                          <label for="cc-payment" class="control-label mb-1">Book Isbn</label>
                                          <asp:TextBox ID="bookisbn" runat="server" CssClass="form-control"></asp:TextBox>
                                      </div>

                                       <div class="form-group">
                                          <label for="cc-payment" class="control-label mb-1">Book Quantity</label>
                                          <asp:TextBox ID="bookquantity" runat="server" CssClass="form-control"></asp:TextBox>
                                      </div>
                                     
                                     
                                      
                                      <div>
                                         

                                         <asp:Button ID="btnadd" class="btn btn-lg btn-info btn-block"  runat="server" Text="Add New Books" OnClick="btnadd_Click" />
                                      </div>
                                        <div class="alert alert-success"  id="msg" runat="server" style="margin-top:10px; display:none">
                           <strong>Book Added Successfully </strong>
                        </div>
                                  </form>
                              </div>
                          </div>

                        </div>
                    </div> <!-- .card -->

                  </div>
</asp:Content>
