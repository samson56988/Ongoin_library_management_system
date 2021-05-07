<%@ Page Title="" Language="C#" MasterPageFile="~/Libarian/Site1.Master" AutoEventWireup="true" CodeBehind="Penalty.aspx.cs" Inherits="Library_Managment_System.Libarian.Penalty" %>
<asp:Content ID="Content1" ContentPlaceHolderID="cl" runat="server">
     <div class="col-lg-12">
                    <div class="card">
                        <div class="card-header">
                            <strong class="card-title">Add/Edit Penalty</strong>
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
                                          <label for="cc-payment" class="control-label mb-1">Add Edit Penalty ($)</label>
                                          <asp:TextBox ID="penalty" runat="server" CssClass="form-control"></asp:TextBox>
                                      </div>
                                       
                                       
                                     
                                     
                                      
                                      <div>
                                         

                                         <asp:Button ID="btnpenalty" class="btn btn-lg btn-info btn-block"  runat="server" Text="Add Penalty" OnClick="btnpenalty_Click"/>
                                      </div>
                                        <div class="alert alert-success"  id="msg" runat="server" style="margin-top:10px; display:none">
                           <strong></strong>
                        </div>
                                  </form>
                              </div>
                          </div>

                        </div>
                    </div> <!-- .card -->

                  </div>

</asp:Content>
