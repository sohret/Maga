<%@ Page Title="" Language="C#" MasterPageFile="~/Default.Master" AutoEventWireup="true" CodeBehind="ListOfColor.aspx.cs" Inherits="PAdmin.WF.ListOfColor" %>
<%@ Register assembly="DevExpress.Web.v16.1, Version=16.1.11.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v16.1, Version=16.1.11.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Data.Linq" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <dx:ASPxGridView ID="grid" runat="server" AutoGenerateColumns="False" DataSourceID="EntityServerModeDataSource1" KeyFieldName="ID" ClientInstanceName="grid" OnRowInserting="grid_RowInserting" OnInitNewRow="grid_InitNewRow" OnLoad="grid_Load" OnRowDeleting="grid_RowDeleting" OnRowUpdating="grid_RowUpdating" OnCellEditorInitialize="grid_CellEditorInitialize">
        <SettingsContextMenu EnableColumnMenu="True" Enabled="True" EnableFooterMenu="True" EnableGroupFooterMenu="True" EnableGroupPanelMenu="True" EnableRowMenu="True">
        </SettingsContextMenu>
        <SettingsPager PageSize="20">
        </SettingsPager>
        <SettingsEditing EditFormColumnCount="1">
        </SettingsEditing>
        <Settings ShowFilterRow="True" ShowGroupPanel="True" ShowTitlePanel="True" AutoFilterCondition="Contains" ShowFilterBar="Auto" ShowHeaderFilterButton="True" />
        <SettingsBehavior ColumnResizeMode="Control" ConfirmDelete="True" />
        <SettingsCookies CookiesID="ListOfColorGrid" Enabled="True" Version="2" />
        <SettingsSearchPanel ShowApplyButton="True" ShowClearButton="True" Visible="True" />
        <SettingsText Title="Color" />
        <Columns>
            <dx:GridViewCommandColumn ShowClearFilterButton="True" ShowDeleteButton="True" ShowEditButton="True" ShowNewButtonInHeader="True" VisibleIndex="0">
            </dx:GridViewCommandColumn>
            <dx:GridViewDataTextColumn FieldName="ID" ReadOnly="True" VisibleIndex="1" Caption="ID">
                <Settings AllowHeaderFilter="False" />
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn FieldName="Name" VisibleIndex="4" Caption="Rəng adı">
                <PropertiesTextEdit Width="200px">
                    <ValidationSettings CausesValidation="True">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesTextEdit>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataDateColumn FieldName="InsertDate" VisibleIndex="7" Caption="Daxiletmə tarixi">
                <PropertiesDateEdit DisplayFormatString="g">
                </PropertiesDateEdit>
                <SettingsHeaderFilter Mode="DateRangePicker">
                </SettingsHeaderFilter>
                <EditFormSettings Visible="False" />
                <CellStyle HorizontalAlign="Right">
                </CellStyle>
            </dx:GridViewDataDateColumn>
            <dx:GridViewDataComboBoxColumn FieldName="LanguageID" VisibleIndex="3" Caption="Dil">
                <PropertiesComboBox TextField="Name" ValueField="ID" ValueType="System.Int32">
                    <ValidationSettings CausesValidation="True">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesComboBox>
                <SettingsHeaderFilter Mode="CheckedList">
                </SettingsHeaderFilter>
            </dx:GridViewDataComboBoxColumn>
            <dx:GridViewDataColorEditColumn FieldName="HexCode" VisibleIndex="5" Caption="Rəng HEX kodu">
                <PropertiesColorEdit EnableCustomColors="True" Width="200px">
                    <ValidationSettings CausesValidation="True">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesColorEdit>
                <SettingsHeaderFilter Mode="CheckedList">
                </SettingsHeaderFilter>
            </dx:GridViewDataColorEditColumn>
            <dx:GridViewDataTextColumn FieldName="LangCount" VisibleIndex="8" Caption="Mövcud dil sayı">
                <SettingsHeaderFilter Mode="CheckedList">
                </SettingsHeaderFilter>
                <EditFormSettings Visible="False" />
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataSpinEditColumn FieldName="OrderNo" VisibleIndex="6" Caption="S/n">
                <PropertiesSpinEdit DisplayFormatString="g" Width="200px">
                    <ValidationSettings CausesValidation="True">
                        <RequiredField IsRequired="True" />
                    </ValidationSettings>
                </PropertiesSpinEdit>
                <Settings AllowHeaderFilter="False" />
            </dx:GridViewDataSpinEditColumn>
            <dx:GridViewDataComboBoxColumn Caption="Əsas rəng" FieldName="ColorID" VisibleIndex="2">
                <PropertiesComboBox AllowNull="True" TextField="Name" ValueField="ID" ValueType="System.Int32">
                    <ClearButton DisplayMode="Always">
                    </ClearButton>
                </PropertiesComboBox>
                <SettingsHeaderFilter Mode="CheckedList">
                </SettingsHeaderFilter>
            </dx:GridViewDataComboBoxColumn>
        </Columns>
</dx:ASPxGridView>
    <dx:EntityServerModeDataSource ID="EntityServerModeDataSource1" runat="server" ContextTypeName="PA.Data.Models.ModelPA" TableName="ViewColor" />
</asp:Content>
