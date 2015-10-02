<%@ Page Language="C#" MasterPageFile="~/Admin/adminMain.Master" AutoEventWireup="true" CodeBehind="adminCategories.aspx.cs" Inherits="TihBlogCompact.adminCategories" %>

<asp:Content ID="_mainContent" ContentPlaceHolderID="_mainContentPlaceHolder" runat="server">
  <div class="subMenu">
   &nbsp;<a class="subMenu_link" href="adminMain.aspx"><%= Resources.Resources.Main %></a>
  </div>
  <div style="border-width:0px;" class="article_title">
    <%= Resources.Resources.Categories %>
  </div>

      <asp:GridView ID="_categoriesGV" runat="server" AllowPaging="False" AllowSorting="False" SkinID="AdminGridSkin"
        AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="_categoriesDS" 
        AutoGenerateEditButton="true" OnRowUpdating="_categoriesGV_RowUpdating" OnRowDeleting="_categoriesGV_RowDeleting">
        <Columns>
          <asp:TemplateField HeaderText="">
            <ItemTemplate>
              <asp:LinkButton ID="_deleteLnkBtn" runat="server" CommandName="Delete" Text="Delete" CssClass="controlBtn_link"
                   OnClientClick="return confirm('Are you sure you want to delete this category? (Some article may be on that category)');">
              </asp:LinkButton>
            </ItemTemplate>
          </asp:TemplateField>
          <asp:TemplateField HeaderText="Category Name">
            <ItemTemplate>
               <%# DataBinder.Eval(Container.DataItem, "categoryName") %>
            </ItemTemplate>
            <EditItemTemplate>
               <asp:TextBox ID="_categoryNameTB" runat="server" Width="200px" Text='<%# Bind("categoryName") %>'></asp:TextBox>
               <asp:RequiredFieldValidator ID="_categoryNameRFV" runat="server" Display="Dynamic" ControlToValidate="_categoryNameTB">
                *
               </asp:RequiredFieldValidator>
               <asp:RegularExpressionValidator ID="_categoryNameMaxLen" 
                  runat="server" Display="dynamic" 
                  ControlToValidate="_categoryNameTB" 
                  ValidationExpression="^([\S\s]{0,45})$">
                <br />
                *45 characters max
               </asp:RegularExpressionValidator>
            </EditItemTemplate>
          </asp:TemplateField>
        </Columns>
      </asp:GridView>
      <tasp:TBAccessDataSource ID="_categoriesDS" runat="server" 
              SelectCommand="SELECT [ID], [categoryName] FROM [Category] WHERE [ID] <> 1 ORDER BY [categoryName]"
              UpdateCommand="UPDATE [Category] 
                             SET [categoryName]=@categoryName
                             WHERE [ID]=@ID"
              DeleteCommand="DELETE 
                             FROM [Category]
                             WHERE [ID]=@ID">
                <UpdateParameters>
                  <asp:Parameter Name="categoryName" Type="String" />
                  <asp:Parameter Name="ID" Type="Int64" />
                </UpdateParameters>
                <DeleteParameters>
                  <asp:Parameter Name="ID" Type="Int64" />
                </DeleteParameters>
      </tasp:TBAccessDataSource>

</asp:Content>
