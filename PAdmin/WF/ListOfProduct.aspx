<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ListOfProduct.aspx.cs" Inherits="PAdmin.WF.ListOfProduct" %>

<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.11.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Web" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v16.1, Version=16.1.11.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" Namespace="DevExpress.Data.Linq" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script>var _pCol;</script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dx:ASPxGridView ID="grid" runat="server" AutoGenerateColumns="False" DataSourceID="EntityServerModeDataSource1" KeyFieldName="ID" ClientInstanceName="grid" OnRowInserting="grid_RowInserting" OnInitNewRow="grid_InitNewRow" OnLoad="grid_Load" OnRowDeleting="grid_RowDeleting" OnRowUpdating="grid_RowUpdating" OnCellEditorInitialize="grid_CellEditorInitialize" OnBatchUpdate="grid_BatchUpdate">
        <ClientSideEvents BatchEditEndEditing="function(s, e) {
try {
               e.rowValues[_pCol].text = glProduct.GetText();
               e.rowValues[_pCol].value = glProduct.GetGridView().GetRowKey(glProduct.GetGridView().GetFocusedRowIndex());
           } catch (err) {
               // ignore error on new adds that are blank 
           }
}"
            BatchEditStartEditing="function(s, e) {
if (e.focusedColumn.fieldName === 'ProductID') {
            //alert(e.rowValues[e.focusedColumn.index].value);
            if (e.rowValues[e.focusedColumn.index].value != null) {
               glProduct.SetValue(e.rowValues[e.focusedColumn.index].value);
               glProduct.SetText(e.rowValues[e.focusedColumn.index].text);
            }
               _pCol = e.focusedColumn.index; // save the column position
           }
}" />
        <SettingsContextMenu EnableColumnMenu="True" Enabled="True" EnableFooterMenu="True" EnableGroupFooterMenu="True" EnableGroupPanelMenu="True" EnableRowMenu="True">
        </SettingsContextMenu>
        <SettingsPager PageSize="20" Position="TopAndBottom">
            <PageSizeItemSettings Items="10, 15, 20, 25, 30, 50, 100" Visible="True">
            </PageSizeItemSettings>
        </SettingsPager>
        <SettingsEditing EditFormColumnCount="1" Mode="Batch">
            <BatchEditSettings StartEditAction="Click" />
        </SettingsEditing>
        <Settings ShowFilterRow="True" ShowTitlePanel="True" AutoFilterCondition="Contains" ShowFilterBar="Auto" ShowHeaderFilterButton="True" />
        <SettingsBehavior ColumnResizeMode="Control" ConfirmDelete="True" EnableCustomizationWindow="True" />
        <SettingsCookies CookiesID="ListOfProductGrid" Enabled="True" Version="3" StoreControlWidth="True" />
        <SettingsDataSecurity AllowDelete="False" AllowInsert="False" />
        <SettingsSearchPanel ShowApplyButton="True" ShowClearButton="True" />
        <SettingsText Title="Product" />
        <Columns>
            <dx:GridViewCommandColumn ShowClearFilterButton="True" VisibleIndex="0">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" VisibleIndex="1" Caption="ID" Width="50px">
                <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="URL" Caption="URL" VisibleIndex="8" Width="150px">
                <Settings AllowAutoFilter="True" AllowHeaderFilter="False" />
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Name" FieldName="Name" VisibleIndex="2" Width="200px">
                <Settings AllowAutoFilter="True" AllowHeaderFilter="False" />
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="InsertDate" VisibleIndex="10" Caption="Insert Date" Width="100px">
                <Settings AllowAutoFilter="False" AllowHeaderFilter="True" />
                <SettingsHeaderFilter Mode="DateRangePicker">
                </SettingsHeaderFilter>
                <EditFormSettings Visible="False" />
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataMemoColumn Caption="Comment" FieldName="Comment" VisibleIndex="9" Width="200px">
                <Settings AllowAutoFilter="True" AllowHeaderFilter="False" />
            </dx:GridViewDataMemoColumn>
            <dx:GridViewDataSpinEditColumn Caption="Price" FieldName="Price" VisibleIndex="7" Width="100px">
                <PropertiesSpinEdit DisplayFormatString="g">
                </PropertiesSpinEdit>
                <Settings AllowAutoFilter="True" AllowHeaderFilter="False" />
                <EditFormSettings Visible="False" />
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataComboBoxColumn Caption="Color" FieldName="ColorID" VisibleIndex="6" Width="100px">
                <PropertiesComboBox TextField="Name" ValueField="ID" ValueType="System.Int32">
                </PropertiesComboBox>
                <Settings AllowAutoFilter="False" AllowHeaderFilter="True" />
                <SettingsHeaderFilter Mode="CheckedList">
                </SettingsHeaderFilter>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn Caption="Category" FieldName="CategoryID" VisibleIndex="5" Width="150px">
                <PropertiesComboBox TextField="Name" ValueField="ID" ValueType="System.Int32">
                </PropertiesComboBox>
                <Settings AllowAutoFilter="False" AllowHeaderFilter="True" />
                <SettingsHeaderFilter Mode="CheckedList">
                </SettingsHeaderFilter>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn Caption="Shop" FieldName="ShopID" VisibleIndex="4" Width="100px">
                <PropertiesComboBox TextField="Name" ValueField="ID" ValueType="System.Int32">
                </PropertiesComboBox>
                <Settings AllowAutoFilter="False" AllowHeaderFilter="True" />
                <SettingsHeaderFilter Mode="CheckedList">
                </SettingsHeaderFilter>
                <EditFormSettings Visible="False" />
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataComboBoxColumn Caption="Product" FieldName="ProductID" VisibleIndex="3" Width="200px">
                <PropertiesComboBox DropDownRows="15" TextField="Name" ValueField="ID" ValueType="System.Int32">
                </PropertiesComboBox>
                <Settings AllowAutoFilter="False" AllowHeaderFilter="False" />
                <EditItemTemplate>
                    <dx:ASPxGridLookup ID="glProduct" runat="server" AutoGenerateColumns="False" ClientInstanceName="glProduct" DataSourceID="EntityServerModeDataSource2" KeyFieldName="ID" OnInit="glProduct_Load" Width="100%" TextFormatString="{1}">
                        <GridViewProperties>
                            <SettingsBehavior AllowFocusedRow="True" AllowSelectSingleRowOnly="True" AllowSort="False" ColumnResizeMode="Control" />
                            <Settings AutoFilterCondition="Contains" ShowFilterRow="True" />
                            <SettingsCookies CookiesID="ListOfProductLookup" Enabled="True" Version="2" />
                            <SettingsDataSecurity AllowDelete="False" AllowEdit="False" AllowInsert="False" />
                            <SettingsPager Visible="True" />
                        </GridViewProperties>
                        <Columns>
                            <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" Visible="False" VisibleIndex="0">
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataTextColumn Caption="Product name" FieldName="Name" MinWidth="100" VisibleIndex="1">
                                <Settings AllowAutoFilter="True" AllowHeaderFilter="False" />
                            </dx:GridViewDataTextColumn>
                            <dx:GridViewDataComboBoxColumn Caption="Category" FieldName="CategoryID" MinWidth="50" VisibleIndex="2">
                                <PropertiesComboBox DropDownRows="15" TextField="Name" ValueField="ID" ValueType="System.Int32">
                                </PropertiesComboBox>
                                <Settings AllowAutoFilter="True" AllowFilterBySearchPanel="False" AllowHeaderFilter="False" />
                            </dx:GridViewDataComboBoxColumn>
                            <dx:GridViewDataComboBoxColumn Caption="Brand" FieldName="BrandID" MinWidth="50" VisibleIndex="3">
                                <PropertiesComboBox DropDownRows="15" TextField="Name" ValueField="ID" ValueType="System.Int32">
                                </PropertiesComboBox>
                                <Settings AllowAutoFilter="True" AllowFilterBySearchPanel="False" AllowHeaderFilter="False" />
                            </dx:GridViewDataComboBoxColumn>
                        </Columns>
                    </dx:ASPxGridLookup>
                </EditItemTemplate>
            </dx:GridViewDataComboBoxColumn>
        </Columns>
    </dx:ASPxGridView>
    <dx:EntityServerModeDataSource ID="EntityServerModeDataSource1" runat="server" ContextTypeName="PA.Data.Models.ModelPA" TableName="ShopProduct" />
    <dx:EntityServerModeDataSource ID="EntityServerModeDataSource2" runat="server" ContextTypeName="PA.Data.Models.ModelPA" TableName="Product" />
</asp:Content>
