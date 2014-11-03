Imports System.Web.HttpContext
Imports System.Data.SqlClient
Imports System.Web.UI.WebControls
Imports System.Web.UI.HtmlControls
Imports System.Text.RegularExpressions
Imports System.Web.Configuration


Module MiscFunctions
    Public Sub SetDisplay(ByVal strDisplay As String, ByVal ParamArray Controls() As Control)
        'This is modified to use a variable list of controls
        Dim wc As Control

        For Each wc In Controls
            Dim strType As String = wc.GetType.ToString.ToLower
            If InStr(strType, "html") > 0 Then
                Dim htmlcontrol As HtmlControl = wc
                htmlcontrol.Style("display") = strDisplay
            ElseIf InStr(strType, "checkbox") > 0 Then
                Dim checkbox As Web.UI.WebControls.CheckBox = wc
                checkbox.Style("display") = strDisplay
            ElseIf InStr(strType, "label") > 0 Then
                Dim label As Web.UI.WebControls.Label = wc
                label.Style("display") = strDisplay
            ElseIf InStr(strType, "dropdownlist") > 0 Then
                Dim dropdownlist As Web.UI.WebControls.DropDownList = wc
                dropdownlist.Style("display") = strDisplay
            ElseIf InStr(strType, "textbox") > 0 Then
                Dim textbox As Web.UI.WebControls.TextBox = wc
                textbox.Style("display") = strDisplay
            ElseIf InStr(strType, "linkbutton") > 0 Then
                Dim linkbutton As Web.UI.WebControls.LinkButton = wc
                linkbutton.Style("display") = strDisplay
            ElseIf InStr(strType, "imagebutton") > 0 Then
                Dim imagebutton As Web.UI.WebControls.ImageButton = wc
                imagebutton.Style("display") = strDisplay
            ElseIf InStr(strType, "hyperlink") > 0 Then
                Dim link As Web.UI.WebControls.HyperLink = wc
                link.Style("display") = strDisplay
            ElseIf InStr(strType, "radiobuttonlist") > 0 Then
                Dim radiobutton As Web.UI.WebControls.RadioButtonList = wc
                radiobutton.Style("display") = strDisplay
            End If
        Next
    End Sub

    Public Function Settings(ByVal cnnSQL As SqlConnection) As DataTable
        Dim cmd As New SqlCommand("[Admin].[usp_GetSettings]", cnnSQL)
        Return FillDataTable(cmd)
    End Function
    Public Function Settings(ByVal cnnSQL As SqlConnection, ByVal pcSetting As String, Optional ByVal dtSettings As DataTable = Nothing) As String
        If dtSettings Is Nothing Then
            Dim cmd As New SqlCommand("[Admin].[usp_GetSettings]", (New Connection).cnnSQL)
            dtSettings = FillDataTable(cmd)
        End If
        Dim dv As New DataView(dtSettings)
        dv.RowFilter = "cSetting = '" & pcSetting & "'"
        If dv.Count > 0 Then
            Return dv(0).Item("cValue")
        End If
        Return ""
    End Function
    Public Function FillDataTable(ByRef pCommand As SqlCommand,
                              Optional ByVal pcTableName As String = "Table", Optional ByVal plFixNulls As Boolean = True) As DataTable
        Dim dt As New DataTable

        Dim daSql As New SqlDataAdapter

        pCommand.CommandType = CommandType.StoredProcedure

        daSql.SelectCommand = pCommand

        Try
            CnnSqlOpen(pCommand.Connection)
            daSql.Fill(dt)
        Catch ex As Exception
            Throw
        Finally
            ''Only close the connection if there isn't a transaction associated with the command
            If pCommand.Transaction Is Nothing Then
                pCommand.Connection.Close()
            End If
            daSql.Dispose()
            pCommand.Dispose()
        End Try

        dt.TableName = pcTableName
        If plFixNulls Then
            FixNulls(dt)
        End If

        Return dt

    End Function

    Public Sub FixNulls(ByRef pdsSet As DataSet)
        Try
            For Each dtTable As DataTable In pdsSet.Tables
                FixNulls(dtTable)
            Next
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub FixNulls(ByRef pdtTable As DataTable)
        Try
            'Assign a default value to all current Null fields
            For Each dr As DataRow In pdtTable.Rows
                FixNulls(dr, pdtTable)
            Next
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub FixNulls(ByRef pdrRow As DataRow, ByRef pdtTable As DataTable)
        Try
            'Assign a default value to all current Null fields
            Dim myCol As DataColumn

            For Each myCol In pdtTable.Columns
                If IsDBNull(pdrRow.Item(myCol.ColumnName)) Then
                    Select Case Strings.Left(myCol.ColumnName, 1)
                        Case "c", "m"
                            pdrRow.Item(myCol.ColumnName) = ""
                        Case "l"
                            pdrRow.Item(myCol.ColumnName) = False
                        Case "n"
                            pdrRow.Item(myCol.ColumnName) = 0
                        Case "d"
                            pdrRow.Item(myCol.ColumnName) = "01/01/1900"
                        Case "i"
                            pdrRow.Item(myCol.ColumnName) = Guid.Empty
                    End Select
                End If
            Next
        Catch ex As Exception
            Throw
        End Try
    End Sub
    Public Sub CnnSqlOpen(ByVal gcnnSQL As SqlConnection)
        Try
            If gcnnSQL.State = ConnectionState.Closed Then gcnnSQL.Open()
        Catch ex As Exception
            Throw
        End Try
    End Sub



#Region "Object Conversions"
    Public Sub RowToObject(ByRef obj As Object, ByVal row As DataRow, ByVal ParamArray strIgnore() As String)
        Dim t As Type = obj.GetType
        Dim properties As System.Reflection.PropertyInfo() = t.GetProperties()

        For Each prop In properties
            Try
                If Not prop.GetSetMethod Is Nothing Then
                    If strIgnore.Length = 0 Then
                        prop.SetValue(obj, row.Item(prop.Name), Nothing)
                    Else
                        If Not strIgnore.Contains(prop.Name) Then
                            prop.SetValue(obj, row.Item(prop.Name), Nothing)
                        End If
                    End If
                End If
            Catch ex As Exception
                Throw
            End Try
        Next
    End Sub
    Public Sub ObejctToDataTable(ByRef dt As DataTable, ByVal objList As System.Collections.Generic.IEnumerable(Of Object))
        dt.Clear()

        If Not objList Is Nothing Then
            For Each obj In objList
                Dim dr As DataRow = dt.NewRow
                ObejctToDataRow(dr, obj)
                dt.Rows.Add(dr)
            Next
        End If
    End Sub
    Public Sub ObejctToDataRow(ByRef dr As DataRow, ByVal obj As Object)
        Dim t As Type = obj.GetType
        Dim properties As System.Reflection.PropertyInfo() = t.GetProperties()

        For Each col As DataColumn In dr.Table.Columns
            Try
                For Each prop In properties
                    Try
                        If prop.Name = col.ColumnName Then

                            dr.Item(col.ColumnName) = If(prop.GetValue(obj, Nothing), DBNull.Value)
                            Exit For
                        End If
                    Catch ex As Exception
                        Throw ex
                    End Try
                Next
            Catch ex As Exception
                Throw ex
            End Try
        Next
    End Sub
#End Region
End Module
