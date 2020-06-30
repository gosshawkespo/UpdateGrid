Imports System.Data.Odbc
Imports MySql.Data
Imports MySql.Data.MySqlClient
Public Class UpdateGridDAL

    Function GetAPEMast(ConnectString As String, DV As String, SD As String, Cat As String, Sect As String, Page As String,
                        ItemCode As String, ItemDesc As String, strSupplier As String, IsExact As Boolean, SortField As String, Reversed As Boolean) As DataTable
        Dim SQLStatement As String
        Dim cn As New OdbcConnection(ConnectString)
        Dim cm As OdbcCommand = cn.CreateCommand 'Create a command object via the connection
        Dim Criteria As String

        Criteria = ""
        If DV <> "" Then
            If Not IsExact Then
                Criteria += "DV like '%" & DV & "%'"
            Else
                Criteria += "DV= '" & DV & "'"
            End If

        End If

        If SD <> "" Then
            If Criteria <> "" Then
                Criteria += " AND "
            End If
            If Not IsExact Then
                Criteria += "SD like '%" & SD & "%'"
            Else
                Criteria += "SD= '" & SD & "'"
            End If

        End If

        If Cat <> "" Then
            If Criteria <> "" Then
                Criteria += " AND "
            End If
            Criteria += "cata05 ='" & Cat & "'"
        End If

        If Sect <> "" Then
            If Criteria <> "" Then
                Criteria += " AND "
            End If
            Criteria += "sect05 ='" & Sect & "'"
        End If

        If Page <> "" Then
            If Criteria <> "" Then
                Criteria += " AND "
            End If
            Criteria += "Page05 ='" & Page & "'"
        End If

        If ItemCode <> "" Then
            If Criteria <> "" Then
                Criteria += " AND "
            End If
            If Not IsExact Then
                Criteria += "S21ItemCode like '%" & Trim(ItemCode) & "%'"
            Else
                Criteria += "S21ItemCode = '" & Trim(ItemCode) & "'"
            End If

        End If

        If ItemDesc <> "" Then
            If Criteria <> "" Then
                Criteria += " AND "
            End If
            If Not IsExact Then
                Criteria += "Upper(ItemDescription) like '%" & (Trim(ItemDesc.ToUpper)) & "%'"
            Else
                Criteria += "ItemDescription = '" & Trim(ItemDesc) & "'"
            End If

        End If

        If strSupplier <> "" Then
            If Criteria <> "" Then
                Criteria += " AND "
            End If
            If Not IsExact Then
                Criteria += "Upper(snam05) like '%" & Trim(strSupplier.ToUpper) & "%'"
            Else
                Criteria += "snam05 = '" & Trim(strSupplier) & "'"
            End If

        End If

        GetAPEMast = Nothing
        'EPOUTILTST/APEMaster
        SQLStatement = "SELECT " &
            "DV as ""Division"", " &
            "SD as ""Sub Division"", " &
            "RecordID as ""Record ID"", " &
            "trim(S21ItemCode) as ""S21 Item Code"", " &
            "cata05 as ""Category"", " &
            "sect05 as ""Section"", " &
            "Page05 as ""Page"", " &
            "trim(ItemDescription) as ""Item Description"", " &
            "trim(dssp35) as ""Supplier Code"", " &
            "trim(snam05) as ""Supplier Name"", " &
            "NewBuyingPrice as ""New Buying Price"", " &
            "NewSellingPrice as ""New Selling Price"", " &
            "@@Profit as ""Profit"", " &
            "@@Margin as ""Margin%"" " &
            "FROM APEMastV01 "

        If Len(Criteria) > 0 Then
            SQLStatement += " WHERE " & Criteria
        End If
        If SortField <> "" Then
            If SortField.ToUpper <> "UPDATED" Then
                If Reversed Then
                    SQLStatement += " ORDER BY """ & SortField & """ DESC"
                Else
                    SQLStatement += " ORDER BY """ & SortField & """ ASC"
                End If
            Else
                'UPDATED is a boolean column type and not a DB field:
            End If

        Else
            SQLStatement += " ORDER BY ""Record ID"" "
        End If

        '
        'SQLStatement += "fetch first 3000 rows only "
        cn.Open()
        cm.CommandTimeout = 0
        cm.CommandType = CommandType.Text
        cm.CommandText = SQLStatement
        Dim da As New OdbcDataAdapter(cm)
        Dim ds As New DataSet
        da.Fill(ds)
        Return ds.Tables(0)
    End Function

    Function GetAPEMastDetail(ConnectString As String, RecordID As Integer) As DataTable
        Dim SQLStatement As String
        Dim cn As New OdbcConnection(ConnectString)
        Dim cm As OdbcCommand = cn.CreateCommand 'Create a command object via the connection

        SQLStatement = "SELECT " &
            "divn35, " &
            "divn35D, " &
            "sdiv35, " &
            "sdiv35D, " &
            "pgmj35, " &
            "pgmj35D, " &
            "pgmn35, " &
            "pgmn35D, " &
            "RecordID, " &
            "trim(S21ItemCode) as ""S21 Item Code"", " &
            "cata05 as ""Cat"", " &
            "sect05 as ""Sect"", " &
            "Page05 as ""Page"", " &
            "trim(ItemDescription) as ""Item Description"", " &
            "trim(dssp35) as ""Supp Code"", " &
            "trim(snam05) as ""Supplier Name"", " &
            "NewBuyingPrice as ""New Buying Price"", " &
            "NewSellingPrice as ""New Selling Price"", " &
            "@@Profit as ""Profit"", " &
            "@@Margin as ""Margin%"" " &
            "FROM APEMastV02 " &
            "where RecordID = " & RecordID
        cn.Open()
        cm.CommandTimeout = 0
        cm.CommandType = CommandType.Text
        cm.CommandText = SQLStatement
        Dim da As New OdbcDataAdapter(cm)
        Dim ds As New DataSet
        da.Fill(ds)
        Return ds.Tables(0)
    End Function

    Public Function UpdateAPEMast(
                    ConnectString As String,
                    RecordID As Integer,
                    S21ItemCode As String,
                    ItemDescription As String,
                    NewSellingPrice As Decimal,
                    NewBuyingPrice As Decimal
)
        Dim SQLStatement As String
        Dim SQLOK As Boolean = True
        Dim ReworkFlag As String = "0"
        Dim cn As New OdbcConnection(ConnectString)


        cn.Open()
        Dim cm As OdbcCommand = cn.CreateCommand 'Create a command object via the connection
        SQLStatement =
        "Select RecordID  " &
        "From apemast  " &
        "Where RecordID =" & RecordID & " "
        cm.CommandTimeout = 0
        cm.CommandType = CommandType.Text
        cm.CommandText = SQLStatement
        Dim da As New OdbcDataAdapter(cm)
        Dim ds As New DataSet
        da.Fill(ds)
        If ds.Tables(0).Rows.Count > 0 Then
            SQLStatement =
            "Update ApeMast " &
            "set " &
            "S21ItemCode='" & S21ItemCode & "', " &
            "NewSellingPrice=" & NewSellingPrice & ", " &
            "NewBuyingPrice=" & NewBuyingPrice & " " &
            "Where RecordID =" & RecordID & " "
        Else
            SQLStatement =
            "Insert into APEMast ( " &
            "S21ItemCode, " &
            "NewSellingPrice, " &
            "NewBuyingPrice " &
            ")  " &
            "Values(" &
            "'" & S21ItemCode & "' , " &
            NewSellingPrice & ", " &
            NewBuyingPrice & " " &
            ")"
        End If
        cm.CommandText = SQLStatement
        Dim da1 As New OdbcDataAdapter(cm)
        Dim ds1 As New DataSet
        Try
            da1.Fill(ds1)
        Catch ex As Exception
            MsgBox(ex.Message)
            SQLOK = False
        End Try
        Return (SQLOK)
    End Function


    Function GetAPEMaster_MYSQL(ConnectString As String, DV As String, SD As String, Cat As String, Sect As String, Page As String,
                                ItemCode As String, ItemDesc As String, strSupplier As String, IsExact As Boolean, SortField As String, Reversed As Boolean) As DataTable
        Dim SQLStatement As String
        Dim ConnString As String
        Dim ZeroDatetime As Boolean = True
        Dim Server As String = "localhost"
        Dim DbaseName As String = "espotest"
        Dim USERNAME As String = "root"
        Dim password As String = "root"
        Dim port As String = "3306"
        Dim Criteria As String

        Try
            Criteria = ""
            If DV <> "" Then
                If Not IsExact Then
                    Criteria += "DV like '%" & DV & "%'"
                Else
                    Criteria += "DV= '" & DV & "'"
                End If

            End If

            If SD <> "" Then
                If Criteria <> "" Then
                    Criteria += " AND "
                End If
                If Not IsExact Then
                    Criteria += "SD like '%" & SD & "%'"
                Else
                    Criteria += "SD= '" & SD & "'"
                End If

            End If

            If Cat <> "" Then
                If Criteria <> "" Then
                    Criteria += " AND "
                End If
                Criteria += "cata05 ='" & Cat & "'"
            End If

            If Sect <> "" Then
                If Criteria <> "" Then
                    Criteria += " AND "
                End If
                Criteria += "sect05 ='" & Sect & "'"
            End If

            If Page <> "" Then
                If Criteria <> "" Then
                    Criteria += " AND "
                End If
                Criteria += "Page05 ='" & Page & "'"
            End If

            If ItemCode <> "" Then
                If Criteria <> "" Then
                    Criteria += " AND "
                End If
                If Not IsExact Then
                    Criteria += "S21ItemCode like '%" & Trim(ItemCode) & "%'"
                Else
                    Criteria += "S21ItemCode = '" & Trim(ItemCode) & "'"
                End If

            End If

            If ItemDesc <> "" Then
                If Criteria <> "" Then
                    Criteria += " AND "
                End If
                If Not IsExact Then
                    Criteria += "Upper(ItemDescription) like '%" & (Trim(ItemDesc.ToUpper)) & "%'"
                Else
                    Criteria += "ItemDescription = '" & Trim(ItemDesc) & "'"
                End If

            End If

            If strSupplier <> "" Then
                If Criteria <> "" Then
                    Criteria += " AND "
                End If
                If Not IsExact Then
                    Criteria += "Upper(snam05) like '%" & Trim(strSupplier.ToUpper) & "%'"
                Else
                    Criteria += "snam05 = '" & Trim(strSupplier) & "'"
                End If

            End If

            ConnString = String.Format("server={0}; user id={1}; password={2}; database={3}; Convert Zero Datetime={4}; port={5}; pooling=false", Server, USERNAME, password, DbaseName, ZeroDatetime, port)
            Dim cn As New MySqlConnection(ConnString)
            cn.Open()
            Dim cm As MySqlCommand = cn.CreateCommand 'Create a command object via the connection
            GetAPEMaster_MYSQL = Nothing
            'EPOUTILTST/APEMaster
            SQLStatement = "SELECT " &
            "divn35, " &
            "divn35D, " &
            "sdiv35, " &
            "sdiv35D, " &
            "pgmj35, " &
            "pgmj35D, " &
            "pgmn35, " &
            "pgmn35D, " &
            "RecordID as ""Record ID"", " &
            "trim(S21ItemCode) as ""S21 Item Code"", " &
            "cata05 as ""Cat"", " &
            "sect05 as ""Sect"", " &
            "Page05 as ""Page"", " &
            "trim(ItemDescription) as ""Item Description"", " &
            "trim(dssp35) as ""Supp Code"", " &
            "trim(snam05) as ""Supplier Name"", " &
            "CurrentPrice as ""New Buying Price"", " &
            "SellingPrice as ""New Selling Price"", " &
            "Profit as ""Profit"", " &
            "Margin as ""Margin%"" " &
            "FROM APEMaster "

            If Len(Criteria) > 0 Then
                SQLStatement += " WHERE " & Criteria
            End If
            SQLStatement += " ORDER BY RecordID"

            cm.CommandTimeout = 0
            cm.CommandType = CommandType.Text
            cm.CommandText = SQLStatement
            Dim da As New MySqlDataAdapter(cm)
            Dim ds As New DataSet
            da.Fill(ds)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox("Error in GetAPEMaster(): " & ex.Message)
        End Try

    End Function

    Function GetAPEMasterDetail_MYSQL(RecordID As Integer) As DataTable
        Dim SQLStatement As String
        Dim SQLOK As Boolean = True
        Dim ReworkFlag As String = "0"
        Dim ConnString As String
        Dim ZeroDatetime As Boolean = True
        Dim Server As String = "localhost"
        Dim DbaseName As String = "espotest"
        Dim USERNAME As String = "root"
        Dim password As String = "root"
        Dim port As String = "3306"

        Try
            GetAPEMasterDetail_MYSQL = Nothing
            ConnString = String.Format("server={0}; user id={1}; password={2}; database={3}; Convert Zero Datetime={4}; port={5}; pooling=false", Server, USERNAME, password, DbaseName, ZeroDatetime, port)
            Dim cn As New MySqlConnection(ConnString)
            cn.Open()
            Dim cm As MySqlCommand = cn.CreateCommand 'Create a command object via the connection

            SQLStatement = "SELECT " &
            "divn35, " &
            "divn35D, " &
            "sdiv35, " &
            "sdiv35D, " &
            "pgmj35, " &
            "pgmj35D, " &
            "pgmn35, " &
            "pgmn35D, " &
            "RecordID as ""Record ID"", " &
            "trim(S21ItemCode) as ""S21 Item Code"", " &
            "cata05 as ""Cat"", " &
            "sect05 as ""Sect"", " &
            "Page05 as ""Page"", " &
            "trim(ItemDescription) as ""Item Description"", " &
            "trim(dssp35) as ""Supp Code"", " &
            "trim(snam05) as ""Supplier Name"", " &
            "CurrentPrice as ""New Buying Price"", " &
            "SellingPrice as ""New Selling Price"", " &
            "Profit as ""Profit"", " &
            "Margin as ""Margin%"" " &
            "FROM APEMaster " &
            "where RecordID = " & RecordID
            cm.CommandTimeout = 0
            cm.CommandType = CommandType.Text
            cm.CommandText = SQLStatement
            Dim da As New MySqlDataAdapter(cm)
            Dim ds As New DataSet
            Try
                da.Fill(ds)
            Catch ex As Exception
                MsgBox("Error2 in GetAPEMasterDetail_MYSQL: " & ex.Message)
                SQLOK = False
            End Try
            da.Fill(ds)
            Return ds.Tables(0)
        Catch ex As Exception
            MsgBox("Error in GetAPEMasterDetail_MYSQL: " & ex.Message)
            SQLOK = False
        End Try
    End Function

    Public Function UpdateAPEMaster_MYSQL(
                    RecordID As Integer,
                    S21ItemCode As String,
                    ItemDescription As String,
                    SellingPrice As Decimal,
                    CurrentPrice As Decimal
)
        Dim SQLStatement As String
        Dim SQLOK As Boolean = True
        Dim ReworkFlag As String = "0"
        Dim ConnString As String
        Dim ZeroDatetime As Boolean = True
        Dim Server As String = "localhost"
        Dim DbaseName As String = "espotest"
        Dim USERNAME As String = "root"
        Dim password As String = "root"
        Dim port As String = "3306"

        Try
            ConnString = String.Format("server={0}; user id={1}; password={2}; database={3}; Convert Zero Datetime={4}; port={5}; pooling=false", Server, USERNAME, password, DbaseName, ZeroDatetime, port)
            Dim cn As New MySqlConnection(ConnString)
            cn.Open()
            Dim cm As MySqlCommand = cn.CreateCommand 'Create a command object via the connection
            SQLStatement =
                "Select RecordID  " &
                "From apemaster  " &
                "Where RecordID =" & RecordID & " "
            cm.CommandTimeout = 0
            cm.CommandType = CommandType.Text
            cm.CommandText = SQLStatement
            Dim da As New MySqlDataAdapter(cm)
            Dim ds As New DataSet
            da.Fill(ds)
            If ds.Tables(0).Rows.Count > 0 Then
                SQLStatement =
                "Update ApeMaster " &
                "set " &
                "S21ItemCode='" & S21ItemCode & "', " &
                "ItemDescription='" & ItemDescription & "', " &
                "SellingPrice=" & SellingPrice & ", " &
                "CurrentPrice=" & CurrentPrice & " " &
                "Where RecordID =" & RecordID & " "
            Else
                SQLStatement =
                "Insert into APEMaster ( " &
                "S21ItemCode, " &
                "ItemDescription, " &
                "SellingPrice, " &
                "CurrentPrice " &
                ")  " &
                "Values(" &
                "'" & S21ItemCode & "' , " &
                "'" & ItemDescription & "' , " &
                SellingPrice & ", " &
                CurrentPrice & " " &
                ")"
            End If
            cm.CommandText = SQLStatement
            Dim da1 As New MySqlDataAdapter(cm)
            Dim ds1 As New DataSet
            Try
                da1.Fill(ds1)
            Catch ex As Exception
                MsgBox("Error2 in UpdateAPEMaster_MYSQL: " & ex.Message)
                SQLOK = False
            End Try
            Return (SQLOK)
        Catch ex As Exception
            MsgBox("Error in UpdateAPEMaster_MYSQL(): " & ex.Message)
        End Try

    End Function

End Class
