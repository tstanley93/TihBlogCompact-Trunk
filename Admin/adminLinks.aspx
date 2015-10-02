<%@ Page Language="C#" MasterPageFile="~/Admin/adminMain.Master" AutoEventWireup="true" CodeBehind="adminLinks.aspx.cs" Inherits="TihBlogCompact.adminLinks" %>

<asp:Content ID="_mainContent" ContentPlaceHolderID="_mainContentPlaceHolder" runat="server">

  <div class="subMenu">
   &nbsp;<a class="subMenu_link" href="adminMain.aspx"><%= Resources.Resources.Main %></a>
  </div>
  <div style="border-width:0px;" class="article_title">
    <%= Resources.Resources.Links %>
  </div>
  <asp:GridView ID="_linksGV" runat="server" AllowPaging="False" AllowSorting="False" SkinID="AdminGridSkin"
        AutoGenerateColumns="False" DataKeyNames="ID" DataSourceID="_linksDS" 
        AutoGenerateEditButton="true">
    <Columns>
      <asp:TemplateField HeaderText="">
        <ItemTemplate>
           <asp:LinkButton ID="_deleteLnkBtn" runat="server" CommandName="Delete" Text="Delete" CssClass="controlBtn_link"
              OnClientClick="return confirm('Are you sure you want to delete this links?');">
           </asp:LinkButton>
         </ItemTemplate>
      </asp:TemplateField>
      <asp:TemplateField HeaderText="URL">
        <ItemTemplate>
          <%# DataBinder.Eval(Container.DataItem, "URL") %>
        </ItemTemplate>
        <EditItemTemplate>
          <asp:TextBox ID="_urlTB" runat="server" Width="200px" Text='<%# Bind("URL") %>'></asp:TextBox>
          <asp:RequiredFieldValidator ID="_urlRFV" runat="server" Display="Dynamic" ControlToValidate="_urlTB">
            *
          </asp:RequiredFieldValidator>
          <asp:RegularExpressionValidator ID="_categoryNameMaxLen" 
             runat="server" Display="dynamic" 
             ControlToValidate="_urlTB" 
             ValidationExpression="^([\S\s]{0,200})$">
              <br />
              *200 characters max
          </asp:RegularExpressionValidator>
        </EditItemTemplate>
      </asp:TemplateField>
      
      <asp:TemplateField HeaderText="Text">
        <ItemTemplate>
          <%# DataBinder.Eval(Container.DataItem, "urlText") %>
        </ItemTemplate>
        <EditItemTemplate>
          <asp:TextBox ID="_textTB" runat="server" Width="200px" Text='<%# Bind("urlText") %>'></asp:TextBox>
          <asp:RequiredFieldValidator ID="_textRFV" runat="server" Display="Dynamic" ControlToValidate="_textTB">
            *
          </asp:RequiredFieldValidator>
          <asp:RegularExpressionValidator ID="_textREV" 
            runat="server" Display="dynamic" 
            ControlToValidate="_textTB" 
            ValidationExpression="^([\S\s]{0,200})$">
             <br />
             *200 characters max
          </asp:RegularExpressionValidator>
        </EditItemTemplate>
      </asp:TemplateField>
    </Columns>
  </asp:GridView>
  <tasp:TBAccessDataSource ID="_linksDS" runat="server" 
        SelectCommand="SELECT [ID], [URL], [urlText] FROM [Links]"
        UpdateCommand="UPDATE [Links] 
                       SET [URL]=@URL,
                           [urlText]=@urlText
                       WHERE [ID]=@ID"
        DeleteCommand="DELETE 
                       FROM [Links]
                       WHERE [ID]=@ID">
    <UpdateParameters>
      <asp:Parameter Name="URL" Type="String" />
      <asp:Parameter Name="urlText" Type="String" />
      <asp:Parameter Name="ID" Type="Int64" />
    </UpdateParameters>
    <DeleteParameters>
      <asp:Parameter Name="ID" Type="Int64" />
    </DeleteParameters>
  </tasp:TBAccessDataSource>
</asp:Content>
