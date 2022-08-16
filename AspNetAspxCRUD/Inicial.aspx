<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicial.aspx.cs" Inherits="AspNetAspxCRUD.Inicial" EnableViewState="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Armando Ramos Wong 8°B</title>
</head>
<body style="background-color: #C0C0C0; font-family: Arial, Helvetica, sans-serif; font-size: medium">
    <form id="form1" runat="server">
        <div>
            <fieldset style="background-color: #FFFFFF; height: 275px;">
                <legend style="font-weight:bold">User Registration:</legend>
                <asp:Label ID="Label4" runat="server" Text="Armando Ramos Wong 8°B" style="margin-left:500px"></asp:Label>
                <!--Name-->
                <br />
                <br />
                <asp:Label ID="nameLabel" runat="server" Text="Name : " style="font-weight:normal"></asp:Label>
                <asp:TextBox ID="txbNome" runat="server" OnLoad="txbNome_Load" style="margin-left: 41px" Width="169px" BorderColor="Gray" BorderStyle="Solid"></asp:TextBox>
               
                <!--Name Validation-->
                <asp:RegularExpressionValidator 
                    ID="RegularExpressionValidatorName" runat="server" 
                    ErrorMessage="Invalid Name"
                    ControlToValidate="txbNome"
                    ForeColor ="Red" ValidationExpression="^[a-zA-Z ]*$">
                </asp:RegularExpressionValidator>        

                <br />    

                <br />
                
                <!--Last Name-->
                <asp:Label ID="Label1" runat="server" Text="Last Name :" style="font-weight:normal"></asp:Label>
                <asp:TextBox ID="txbLastName" runat="server" style="margin-left: 10px" Width="168px" BorderColor="Gray" BorderStyle="Solid"></asp:TextBox>

                 <!--Last Name Validation-->
                 <asp:RegularExpressionValidator 
                    ID="RegularExpressionValidatorLastName" runat="server" 
                    ErrorMessage="Invalid Last Name"
                    ControlToValidate="txbLastName"
                    ForeColor ="Red" ValidationExpression="^[a-zA-Z ]*$">
                </asp:RegularExpressionValidator>        
                <br />
                <br />

                
                <!--Age Name-->
                <asp:Label ID="Label2" runat="server" Text="Age :" style="font-weight:normal"></asp:Label>
                <asp:TextBox ID="txbIdade" runat="server" style="margin-left: 52px" Width="73px" BorderColor="Gray" BorderStyle="Solid"></asp:TextBox>

                <!--Age Validation-->
                 <asp:RegularExpressionValidator 
                    ID="RegularExpressionValidatorAge" runat="server" 
                    ErrorMessage="Invalid Age"
                    ControlToValidate="txbIdade"
                    ForeColor ="Red" ValidationExpression="^[0-9]{1,2}$">
                </asp:RegularExpressionValidator>      
                <br />
                <br />

                
                <!--Height-->
                <asp:Label ID="Label3" runat="server" Text="Height (cm) :" style="font-weight:normal"></asp:Label>
                <asp:TextBox ID="txbAltura" runat="server" style="margin-left: 2px" Width="72px" BorderColor="Gray" BorderStyle="Solid"></asp:TextBox>
                <asp:RegularExpressionValidator 
                    ID="RegularExpressionValidatorHeight" runat="server" 
                    ErrorMessage="Invalid Height"
                    ControlToValidate="txbAltura"
                    ForeColor ="Red" ValidationExpression="^[0-9]{2,3}$">
                </asp:RegularExpressionValidator>      

                <br />

                <br />
                
                <!--Create Button-->
                <asp:Button ID="btnGravar" runat="server" Text="Save" OnClick="btnGravar_Click" BackColor="Black" ForeColor="White" Width="157px"/>
                <br />
                <br />
               <asp:Label ID="lblGravou" runat="server" Text=""></asp:Label>
                <br />
            </fieldset>
        </div>


        <div>
            <fieldset style="background-color: #FFFFFF; font-weight: normal;">
                <!--Show Elements from DB-->
                <legend style="font-weight:bold">Retrieve Users:</legend>
    
                <asp:GridView ID="GridView1" runat="server" style="margin-left: 38px" Width="411px"></asp:GridView>
                <br />

                <asp:Button ID="btnConsultar" runat="server" Text="Show Users" OnClick="btnConsultar_Click" BackColor="Black" ForeColor="White" />
    
                <asp:Label ID="lblDataReader" runat="server" Text=""></asp:Label>
                <br />
            </fieldset>
        </div>

        <div>
            <fieldset style="background-color: #FFFFFF">
                 <!--Delete Elements from DB-->
                <legend style="font-weight:bold">Delete User:</legend>
                 Select User:
                <!--DropDownList-->
                <asp:DropDownList ID="DropDownListUsers" runat="server"
                    DataTextField="name" DataValueField="id">
                </asp:DropDownList>
                 <br />
                <br />
                
                <asp:Button ID="btnExcluir" runat="server" Text="Delete User" OnClick="btnExcluir_Click" BackColor="Black" ForeColor="White" Width="171px" />
                 <br />
                 <br />
                <asp:Label ID="lblExcluiu" runat="server" Text=""></asp:Label>
                 <br />
                <br />
            </fieldset>
        </div>

        <div>
            <fieldset style="background-color: #FFFFFF">
                 <!--Update Elements from DB-->
                <legend style="font-weight:bold">Update User:</legend>
                <!--ID Update-->
                ID: 
                <asp:TextBox ID="txbIdAlt" runat="server" BorderColor="Gray" BorderStyle="Solid" style="margin-left: 26px" Width="67px"></asp:TextBox>
                
                <!--ID Validation-->
                <asp:RegularExpressionValidator 
                    ID="RegularExpressionValidatorAltID" runat="server" 
                    ErrorMessage="Invalid ID"
                    ControlToValidate="txbIdAlt"
                    ForeColor ="Red" ValidationExpression="^[0-9]{1}$">
                </asp:RegularExpressionValidator>    
                 <br />

                <!--Name Update-->
                <br />
                Name:
                <asp:TextBox ID="txbNomeAlt" runat="server" BorderColor="Gray" BorderStyle="Solid" Width="154px"></asp:TextBox>
                <!--Name Validation-->
                <asp:RegularExpressionValidator 
                    ID="RegularExpressionValidatorAltName" runat="server" 
                    ErrorMessage="Invalid Name"
                    ControlToValidate="txbNomeAlt"
                    ForeColor ="Red" ValidationExpression="^[a-zA-Z ]*$">
                </asp:RegularExpressionValidator>
                 <br />
                <br />
                 <!--Last Name Update-->
                 Last Name:
                 <asp:TextBox ID="txbLastAlt" runat="server" BorderColor="Gray" BorderStyle="Solid"></asp:TextBox>
                 <!--Last Name Validation-->
                <asp:RegularExpressionValidator 
                    ID="RegularExpressionValidatorAltLstName" runat="server" 
                    ErrorMessage="Invalid Last Name"
                    ControlToValidate="txbLastAlt"
                    ForeColor ="Red" ValidationExpression="^[a-zA-Z ]*$">
                </asp:RegularExpressionValidator> 
                <br />
                <br />
                 <!--Age Update-->
                Age:
                <asp:TextBox ID="txbIdadeAlt" runat="server" BorderColor="Gray" BorderStyle="Solid" Width="65px" style="margin-left: 12px"></asp:TextBox>
                 <!--Age Validation-->
                <asp:RegularExpressionValidator 
                    ID="RegularExpressionValidator1" runat="server" 
                    ErrorMessage="Invalid Age"
                    ControlToValidate="txbIdadeAlt"
                    ForeColor ="Red" ValidationExpression="^[0-9]{1,2}$">
                </asp:RegularExpressionValidator>  
                <br />
                <br />
                 <!--Height Update-->
                Height:
                <asp:TextBox ID="txbAlturaAlt" runat="server" BorderColor="Gray" BorderStyle="Solid" Width="59px"></asp:TextBox>
                <!--Height Validation-->
                <asp:RegularExpressionValidator 
                    ID="RegularExpressionValidatorAltHeight" runat="server" 
                    ErrorMessage="Invalid Height"
                    ControlToValidate="txbAlturaAlt"
                    ForeColor ="Red" ValidationExpression="^[0-9]{2,3}$">
                </asp:RegularExpressionValidator>  
                <br />
                <br />
               
                <asp:Button ID="btnAlterar" runat="server" Text="Update" OnClick="btnAlterar_Click" BackColor="Black" ForeColor="White" Width="125px" />
                 <br />
                <br />
                <asp:Label ID="lblAlterou" runat="server" Text=""></asp:Label>
                <asp:Label ID="updateExc" runat="server" Text=""></asp:Label>
                 <br />
            </fieldset>
        </div>

    </form>
</body>
</html>
