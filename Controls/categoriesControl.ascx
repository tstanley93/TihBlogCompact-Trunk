<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="categoriesControl.ascx.cs" Inherits="TihBlogCompact.Controls.categoriesControl" %>

<script type="text/javascript" src='<%= ResolveUrl("~/script/BrowserDetect.js") %>'></script>

<script language="javascript" type="text/javascript">
  
  function SetControlEnable(controlId, valDisabled)
  {
    if (BrowserDetect.browser == "Explorer" /* && BrowserDetect.version >= 6 */)
    {
        var cntrl = this.document.getElementById(controlId);
        
        if (cntrl != null)
        {
            cntrl.disabled = valDisabled;
            
            checkboxes = cntrl.getElementsByTagName('input');
            if (checkboxes != null)
            {
                for (var i = 0; i < checkboxes.length; ++i)
                {
                    checkboxes[i].disabled = valDisabled;
                }
            }
            
            spans = cntrl.getElementsByTagName('span');
            if (spans != null)
            {
                for (var i = 0; i < spans.length; ++i)
                {
                    spans[i].disabled = valDisabled;
                }
            }
        }
    }
    else
    {
        var cntrl = $get(controlId);
    
        if (cntrl != null)
        {
            cntrl.disabled = valDisabled;
            
            checkboxes = cntrl.getElementsByTagName('input');
            if (checkboxes != null)
            {
                for (var i = 0; i < checkboxes.length; ++i)
                {
                    checkboxes[i].disabled = valDisabled;
                }
            }
        }
     }
  }
  
  function CheckCustomCategories(allRadioBtnId, checkboxesDivId)
  {
    if (BrowserDetect.browser == "Explorer" /* && BrowserDetect.version >= 6 */)
    {
        var allRadioBtn = this.document.getElementById(allRadioBtnId);
        
        if (allRadioBtn == null)
            return false;
            
        // if all categories is checked    
        if (allRadioBtn.checked)
            return true;
        
        // custom categories: check if at least on category is checked
        checkboxesDiv = this.document.getElementById(checkboxesDivId);
        
        if (checkboxesDiv == null)
            return false;
        
        selectedCategory = false;    
        checkboxes = checkboxesDiv.getElementsByTagName('input');
        if (checkboxes != null)
        {
            for (var i = 0; i < checkboxes.length; ++i)
            {
                if (checkboxes[i].checked)
                {
                    selectedCategory = true;
                    break;
                }
            }
        }
        
        if (!selectedCategory)
        {
            alert('Please, select at least one category!');
            return false;
        }
        
        return true;
    }
    else
    {
        var allRadioBtn = $get(allRadioBtnId);
        
        if (allRadioBtn == null)
            return false;
            
        // if all categories is checked    
        if (allRadioBtn.checked)
            return true;
        
        // custom categories: check if at least on category is checked
        checkboxesDiv = this.document.getElementById(checkboxesDivId);
        
        if (checkboxesDiv == null)
            return false;
        
        selectedCategory = false;    
        checkboxes = checkboxesDiv.getElementsByTagName('input');
        if (checkboxes != null)
        {
            for (var i = 0; i < checkboxes.length; ++i)
            {
                if (checkboxes[i].checked)
                {
                    selectedCategory = true;
                    break;
                }
            }
        }
        
        if (!selectedCategory)
        {
            alert('Please, select at least one category!');
            return false;
        }
        
        return true;    
    }
  }
  
</script>

<div>
 <table>
   <tr>
     <td>
      <asp:RadioButton ID="_allRdoBtn" runat="server" GroupName="_categoriesGroup" />
     </td>
    </tr>
    <tr>
     <td>
      <asp:RadioButton ID="_selectRdoBtn" runat="server" GroupName="_categoriesGroup" />
      <asp:Panel ID="_customCategoriesPanel" runat="server" style="margin-left:20px;">
          <asp:CheckBoxList ID="_categoriesChBList" runat="server" DataSourceID="_categoriesDS"
              DataTextField="categoryName" DataValueField="ID">
          </asp:CheckBoxList>
          <tasp:TBAccessDataSource ID="_categoriesDS" runat="server"
              SelectCommand="SELECT [ID], [categoryName] FROM [Category] WHERE ([ID] <> 1) ORDER BY [categoryName]">
          </tasp:TBAccessDataSource>
          &nbsp;</asp:Panel>
     </td>
   </tr>
 </table>
</div>