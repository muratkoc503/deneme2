<%@ Page Language="C#" AutoEventWireup="true" CodeFile="WebForm1.aspx.cs" Inherits="WebForm1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .label-row {
            display: flex;
            align-items: center;
            margin-bottom: 10px;
        }

        .label-row .label-title {
            width: 150px;
            font-weight: bold;
        }

        .input-row {
            display: flex;
            align-items: center;
            margin-bottom: 10px;
        }

        .input-row .input-label {
            margin-right: 10px;
        }

        .small-input {
            width: 100px;
            height: 15px;
        }

        .form-container {
            display: flex;
            flex-direction: column;
        }

        .form-container .form-row {
            display: flex;
            align-items: center;
        }

        .form-container .form-row .form-element {
            margin-right: 10px;
        }

        .form-container .form-row .form-element .filter-button {
            padding: 5px 10px;
            font-size: 16px;
            width: 80px;
            height: 40px;
        }

        .table-container table {
            width: 100%;
            border-collapse: collapse;
        }

        .table-container th, .table-container td {
            border: 1px solid #337ab7;
            padding: 8px;
        }

        .table-container th {
            background-color: #337ab7;
            color: #fff;
        }

        .table-container tr:nth-child(even) {
            background-color: #f2f2f2;
        }

        .table-container tr:hover {
            background-color: #ddd;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <br />
        <div class="form-container">
            <div class="form-row">
                <div class="form-element">
                    <span class="label-title">Müşteri Adı:</span>
                    <asp:TextBox ID="txtCustomerName" runat="server" CssClass="input-label small-input"></asp:TextBox>
                </div>
                <div class="form-element">
                    <span class="label-title">Üretim Tipi:</span>
                    <asp:DropDownList ID="ddlProductionType" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProductionType_SelectedIndexChanged">
                        <asp:ListItem Text="Tümü" Value=""></asp:ListItem>
                        <asp:ListItem Text="3mm" Value="3mm"></asp:ListItem>
                        <asp:ListItem Text="10mm" Value="10mm"></asp:ListItem>
                        <asp:ListItem Text="16mm" Value="16mm"></asp:ListItem>
                        <asp:ListItem Text="Kalıp" Value="Kalıp"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-element">
                    <span class="label-title">Durum:</span>
                    <asp:DropDownList ID="ddlDurum" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlProductionType_SelectedIndexChanged">
                        <asp:ListItem Text="Tümü" Value=""></asp:ListItem>
                        <asp:ListItem Text="beklemede" Value="beklemede"></asp:ListItem>
                        <asp:ListItem Text="üretimde" Value="üretimde"></asp:ListItem>
                        <asp:ListItem Text="tamamlandı" Value="tamamlandı"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="form-element">
                    <span class="label-title">Tamamlayan Personel:</span>
                    <asp:TextBox ID="txtTamamlayanPerson" runat="server" CssClass="input-label small-input"></asp:TextBox>
                </div>
                <div class="form-element">
                    <asp:Button ID="btnFilter" runat="server" Text="Filtrele" OnClick="btnFilter_Click" CssClass="filter-button" />
                </div>
                <div class="form-element">
                    <asp:Button ID="btnExportToExcel" runat="server" Text="Excel'e Aktar" OnClick="btnExportToExcel_Click" />
       <asp:Button ID="btnOpenFolder" runat="server" Text="Klasörü Aç" OnClientClick="openFolder()" />
                </div>
            </div>
            <br />
            <div class="table-container">
                <asp:GridView ID="gridView" runat="server"></asp:GridView>
            </div>
            <br />
            <asp:Label ID="lblResults" runat="server" Text=""></asp:Label>

        </div>
    </form>
    

<script type="text/javascript">
    function openFolder() {
        // Klasörü açmak için kullanılan input elementinin dinamik olarak oluşturulması
        var input = document.createElement("input");
        input.type = "file";
        input.style.display = "none";
        input.setAttribute("webkitdirectory", "");
        input.setAttribute("mozdirectory", "");
        input.setAttribute("msdirectory", "");
        input.setAttribute("odirectory", "");
        input.setAttribute("directory", "");

        // Input elementine değişiklik olayı (change event) atanması
        input.addEventListener("change", function (e) {
            var selectedFolder = e.target.files[0].path;

            // Seçilen klasörün açılması
            window.open("file:///" + selectedFolder);
        });

        // Input elementinin tıklanmasının tetiklenmesi
        input.click();

        // Input elementinin sayfadan kaldırılması
        document.body.removeChild(input);
    }
</script>

</body>
</html>
