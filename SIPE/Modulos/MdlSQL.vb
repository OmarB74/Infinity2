Option Explicit On
Option Strict On

Imports System.Data.SqlClient
Imports System.Text.RegularExpressions
Imports System.IO
Imports System.Configuration
Imports System.Xml
Module MdlSQL
    Public pServer As String = ""
    Public pBD As String = ""
    'Public cstrConnectBD As String = ""
    Public sUsuarioDB As String = ""
    Public sPasswordUsuarioDB As String = ""
    Public Key As String = "123"
    Public cstrConnectBDapp As String = ""
    Public iEmpresaId As Integer
    Public iUsuario As Integer
    Public iRenovar As Integer
    Public NombreUsuario As String = ""
    Public iProfileId As Integer
    Private Cnn As SqlConnection
    Private cmd As SqlCommand
    Private param As SqlParameter
    Private da As SqlDataAdapter
    Public LlenaCombosStatus As Boolean
    Public LlenaCombosStatusVehiculo As Boolean
    Public iUsuarioBusqueda As Integer
    Public iProveedorBusqueda As Integer
    Public sFechaSistema As Date
    Public bCerrarForma As Boolean = False
    'Public sBusqueda As String
    Public bRealizarBusqueda As Boolean = False
    Public bRealizarBusquedaCondicionada As Boolean = False
    Public iARProveedor As Integer = 0
    '
    Public iSucursalBusqueda As Integer
    Public iLPPBusqueda As Integer
    Public sCodigoBarrasV As String = ""
    Public bRealizaBusquedaVentanilla As Boolean = False
    Public bRealizarCobro As Boolean = False
    Public XMLNotaVentaDetalle As String
    Public iNotaId As Integer = 0
    '
    Public sSucursal As String = ""
#Region "Variable spublicas para busqueda"
    Public iFoliobusqueda As Integer = 0
    Public sNombresbusqueda As String = ""
    Public sApellidosbusqueda As String = ""
    Public sRazonSocialbusqueda As String = ""
    Public sCodigoProducto As String = ""
    Public sProducto As String = ""
    Public sCodigodeBarras As String = ""
#End Region
    Public Function GetcstrConnectBDapp(ByVal strServer As String) As String
        GetcstrConnectBDapp = ""
        '
        Dim m_xmlr As XmlTextReader
        'Creamos el TextReader
        m_xmlr = New XmlTextReader(My.Application.Info.DirectoryPath & "\conexion.xml")
        'Desabilitamos las lineas en blanco, 
        'ya no las necesitamos
        m_xmlr.WhitespaceHandling = WhitespaceHandling.None
        'Leemos el archivo y avanzamos al tag de servidor
        m_xmlr.Read()
        'Leemos el tag servidor
        m_xmlr.Read()
        '
        Select Case strServer
            Case "PRODUCCION" ' servidor de produccion con base de datos de pruebas
                While Not m_xmlr.EOF
                    'Avanzamos al siguiente tag
                    m_xmlr.Read()
                    'si no tenemos el elemento inicial 
                    'debemos salir del ciclo
                    If Not m_xmlr.IsStartElement() Then
                        Exit While
                    End If

                    'Obtenemos el elemento produccion
                    Dim mServidorProduccion = m_xmlr.GetAttribute("produccion")
                    mServidorProduccion = EncryptionDecryption.Decrypt(RTrim(mServidorProduccion), Key)
                    pServer = mServidorProduccion
                    '
                    m_xmlr.Read()

                    'Obtenemos el elemento del usuario
                    Dim musuario = m_xmlr.ReadElementString("usuario")
                    musuario = EncryptionDecryption.Decrypt(RTrim(musuario), Key)
                    sUsuarioDB = musuario

                    'Obtenemos el elemento del password
                    Dim mpassword = m_xmlr.ReadElementString("password")
                    mpassword = EncryptionDecryption.Decrypt(RTrim(mpassword), Key)
                    sPasswordUsuarioDB = mpassword

                    'Obtenemos el elemento del base de produccion
                    Dim mbase_app = m_xmlr.ReadElementString("base_app")
                    mbase_app = EncryptionDecryption.Decrypt(RTrim(mbase_app), Key)
                    pBD = mbase_app
                    '
                    GetcstrConnectBDapp = "Data Source=" & mServidorProduccion & ";Initial Catalog=" & mbase_app & ";Trusted_Connection=NO;Connect Timeout=180;User ID=" & musuario & ";Password=" & mpassword & ";MultipleActiveResultSets=true"
                End While
                '
                'Cerramos la lectura del archivo
                m_xmlr.Close()
                '
                strServer = "Produccion"
                '
                'Cerramos la lectura del archivo
                m_xmlr.Close()
        End Select
    End Function

    Public Function Obtener_Perfil() As DataSet
        Dim ds As New DataSet
        Dim sError As String
        Try
            Cnn = New SqlConnection(cstrConnectBDapp)
            cmd = New SqlCommand("select GrupoId,DescGrupo from Perfil Where EstatusId = 1", Cnn)
            cmd.CommandType = CommandType.Text       'asignar tipo de instruccion a ejecutar

            da = New SqlDataAdapter  'crear objeto data adapter
            da.SelectCommand = cmd     'ejecutar objeto command
            da.Fill(ds, "Perfil")       'llenar dataset
        Catch ex As SqlException
            sError = ex.Number & "-" & ex.Message
        Catch ex As Exception
            sError = ex.Source & "-" & ex.Message
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try
        Return ds
    End Function
    Public Function Obtener_Sucursal() As DataSet
        Dim ds As New DataSet
        Dim sError As String
        Try
            Cnn = New SqlConnection(cstrConnectBDapp)
            cmd = New SqlCommand("Select SucursalId,Descripcion from Cat_Sucursal where estatusid = 1 order by SucursalId", Cnn)
            cmd.CommandType = CommandType.Text       'asignar tipo de instruccion a ejecutar

            da = New SqlDataAdapter  'crear objeto data adapter
            da.SelectCommand = cmd     'ejecutar objeto command
            da.Fill(ds, "Sucursales")       'llenar dataset
        Catch ex As SqlException
            sError = ex.Number & "-" & ex.Message
        Catch ex As Exception
            sError = ex.Source & "-" & ex.Message
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try
        Return ds
    End Function

    Public Function ABMUsuario(ByVal Usuario As FrmUsuario, bBaja As Boolean) As Boolean
        ABMUsuario = False
        Dim Transaccion As SqlTransaction = Nothing
        Dim UsuarioId As String = ""
        Dim ITipoUsuario As Integer = 0
        Try
            Cnn = New SqlConnection()
            Cnn.ConnectionString = cstrConnectBDapp
            Cnn.Open()

            With Usuario
                Transaccion = Cnn.BeginTransaction
                cmd = Cnn.CreateCommand
                cmd.CommandText = "spABM_Usuario"
                '
                cmd.CommandType = CommandType.StoredProcedure
                '
                If bBaja = False Then
                    If .TxtUserId.Text.Equals("") Then
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@Accion", 1))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@UserId", 0))
                    Else
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@Accion", 3))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@UserId", .TxtUserId.Text))
                    End If
                Else
                    cmd.Parameters.Add(New SqlClient.SqlParameter("@Accion", 2))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("@UserId", .TxtUserId.Text))
                End If

                cmd.Parameters.Add(New SqlClient.SqlParameter("@Login", .TxtLogin.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Nombre", .TxtNombre.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Email", ""))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Password", EncryptionDecryption.Encrypt(.TxtPassword.Text, Key)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@PerfilId", .cboPerfil.SelectedValue))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@SucursalId", .cboSucursal.SelectedValue))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@RenovarPass", 0))
                If .chkAdministrador.Checked Then
                    ITipoUsuario = 1
                Else
                    If .chkSupervisor.Checked Then
                        ITipoUsuario = 3
                    Else
                        ITipoUsuario = 2
                    End If
                End If

                cmd.Parameters.Add(New SqlClient.SqlParameter("@TipoUsuarioId", ITipoUsuario))

                cmd.Transaction = Transaccion
                If bBaja = False Then
                    If .TxtUserId.Text.Equals("") Then
                        Dim read As SqlDataReader = cmd.ExecuteReader()
                        read.Read()
                        UsuarioId = CStr(read(0))
                        MsgBox("Datos de Usuario registrados con exito")
                        read.Close()
                    Else
                        cmd.ExecuteNonQuery()
                        MsgBox("Datos de Usuario actualizado con exito")
                    End If
                Else
                    cmd.ExecuteNonQuery()
                    MsgBox("El Usuario se dio de baja con exito")
                End If
            End With

            cmd.Dispose()
            Transaccion.Commit()
            Usuario.TxtUserId.Text = UsuarioId
            ABMUsuario = True
        Catch ex As SqlException
            Transaccion.Rollback()
            MsgBox(ex.Number & "-" & ex.Message, MsgBoxStyle.Critical)
        Catch ex As Exception
            Transaccion.Rollback()
            MsgBox(ex.Message)
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try

    End Function

    Public Function ValidarUsuario(ByVal objeto As FrmUsuario) As Boolean
        ValidarUsuario = True
        Dim faltantes As String = "Campos Faltantes: " & vbCrLf

        With objeto
            If validar_Nombre_usuario(.TxtLogin.Text) Then
                faltantes &= "- Nombre de Usuario" & vbCrLf
                ValidarUsuario = False
            End If

            If .TxtPassword.Text = "" Then
                faltantes &= "- Contraseña" & vbCrLf
                ValidarUsuario = False
            End If

            If .TxtNombre.Text = "" Then
                faltantes &= "- Nombre completo" & vbCrLf
                ValidarUsuario = False
            End If

            'If validar_Mail(.txtCorreo.Text) = False Then

            '    faltantes &= "- Correo incorrecta" & vbCrLf
            '    ValidarUsuario = False
            'End If

            'If .Imagen.Image Is Nothing Then
            '    faltantes &= "- Imagen" & vbCrLf
            '    ValidarUsuario = False
            'End If

        End With

        If ValidarUsuario = False Then
            MsgBox(faltantes)

        End If
    End Function

    Public Function ValidarSucursal(ByVal objeto As FrmSucursal) As Boolean
        ValidarSucursal = True
        Dim faltantes As String = "Campos Faltantes: " & vbCrLf

        With objeto
            If validar_Nombre_usuario(.txtRazonSocial.Text) Then
                faltantes &= "- Descripcion de sucursal" & vbCrLf
                ValidarSucursal = False
            End If

            If .txtCalle.Text = "" Then
                faltantes &= "- Calle" & vbCrLf
                ValidarSucursal = False
            End If

            If .txtNumExterior.Text = "" Then
                faltantes &= "- Numero Exterior" & vbCrLf
                ValidarSucursal = False
            End If

            If validar_Mail(.txtemail.Text) = False Then

                faltantes &= "- Correo incorrecta" & vbCrLf
                ValidarSucursal = False
            End If

            'If .Imagen.Image Is Nothing Then
            '    faltantes &= "- Imagen" & vbCrLf
            '    ValidarUsuario = False
            'End If

        End With

        If ValidarSucursal = False Then
            MsgBox(faltantes)
        End If
    End Function
    Public Function validar_Nombre_usuario(ByVal sUsuario As String) As Boolean
        Dim pattern As String = "/^[a-z\d_]{4,15}$/i"


        Dim miTextoMatch As Match = Regex.Match(sUsuario, pattern)

        Return miTextoMatch.Success
    End Function
    Public Function Obtener_Precios(ByVal strConexion As String) As DataSet
        Dim ds As New DataSet
        Dim sError As String
        Try
            Cnn = New SqlConnection(strConexion)
            cmd = New SqlCommand("Select TipoPrecioId,upper(Descripcion_Tipo_Precio) as Descripcion_Tipo_Precio from Cat_TipoPrecio", Cnn)
            cmd.CommandType = CommandType.Text       'asignar tipo de instruccion a ejecutar

            da = New SqlDataAdapter  'crear objeto data adapter
            da.SelectCommand = cmd     'ejecutar objeto command
            da.Fill(ds, "Precios")       'llenar dataset
        Catch ex As SqlException
            sError = ex.Number & "-" & ex.Message
        Catch ex As Exception
            sError = ex.Source & "-" & ex.Message
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try
        Return ds
    End Function
    Public Function Obtener_Pais(ByVal strConexion As String) As DataSet
        Dim ds As New DataSet
        Dim sError As String
        Try
            Cnn = New SqlConnection(strConexion)
            cmd = New SqlCommand("Select Paisid,upper(DescPais) as DescPais from Cat_Pais", Cnn)
            cmd.CommandType = CommandType.Text       'asignar tipo de instruccion a ejecutar

            da = New SqlDataAdapter  'crear objeto data adapter
            da.SelectCommand = cmd     'ejecutar objeto command
            da.Fill(ds, "Pais")       'llenar dataset
        Catch ex As SqlException
            sError = ex.Number & "-" & ex.Message
        Catch ex As Exception
            sError = ex.Source & "-" & ex.Message
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try
        Return ds
    End Function
    Public Function Obtener_Estados(ByVal strConexion As String, PaisId As Integer) As DataSet
        Dim ds As New DataSet
        Dim sError As String
        Try
            Cnn = New SqlConnection(strConexion)
            cmd = New SqlCommand("Select Estadoid,upper(DescEstado) as DescEstado from CAT_ESTADO Where PaisId = " & PaisId & "", Cnn)
            cmd.CommandType = CommandType.Text       'asignar tipo de instruccion a ejecutar

            da = New SqlDataAdapter  'crear objeto data adapter
            da.SelectCommand = cmd     'ejecutar objeto command
            da.Fill(ds, "ESTADOS")       'llenar dataset
        Catch ex As SqlException
            sError = ex.Number & "-" & ex.Message
        Catch ex As Exception
            sError = ex.Source & "-" & ex.Message
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try
        Return ds
    End Function

    Public Function Obtener_Municipio(ByVal strConexion As String, EstadoId As Integer, PaisId As Integer) As DataSet
        Dim ds As New DataSet
        Dim sError As String
        Try
            Cnn = New SqlConnection(strConexion)
            cmd = New SqlCommand("select Poblacionid,upper(DescPoblacion) as DescPoblacion from Cat_Poblacion where Paisid = " & PaisId & " and estadoId = " & EstadoId, Cnn)
            cmd.CommandType = CommandType.Text       'asignar tipo de instruccion a ejecutar

            da = New SqlDataAdapter  'crear objeto data adapter
            da.SelectCommand = cmd     'ejecutar objeto command
            da.Fill(ds, "Municipio")       'llenar dataset
        Catch ex As SqlException
            sError = ex.Number & "-" & ex.Message
        Catch ex As Exception
            sError = ex.Source & "-" & ex.Message
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try
        Return ds
    End Function

    Public Function Obtener_Colonia(ByVal strConexion As String, MunicipioId As Integer, EstadoId As Integer, PaisId As Integer) As DataSet
        Dim ds As New DataSet
        Dim sError As String
        Try
            Cnn = New SqlConnection(strConexion)
            cmd = New SqlCommand("select ColoniaId,upper(DescColonia) as DescColonia from Cat_Colonia where PaisId = " & PaisId & " and EstadoId  = " & EstadoId & " and PoblacionId=" & MunicipioId, Cnn)
            cmd.CommandType = CommandType.Text       'asignar tipo de instruccion a ejecutar

            da = New SqlDataAdapter  'crear objeto data adapter
            da.SelectCommand = cmd     'ejecutar objeto command
            da.Fill(ds, "Colonia")       'llenar dataset
        Catch ex As SqlException
            sError = ex.Number & "-" & ex.Message
        Catch ex As Exception
            sError = ex.Source & "-" & ex.Message
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try
        Return ds
    End Function
    Public Function Busqueda_Usuarios(ByVal listado As ListView) As Boolean
        Busqueda_Usuarios = True
        Dim cadena(2) As String
        Try

            Cnn = New SqlConnection()
            Cnn.ConnectionString = cstrConnectBDapp
            Cnn.Open()
            '
            cmd = Cnn.CreateCommand
            cmd.CommandText = "spBusqueda_Usuarios"
            cmd.CommandType = CommandType.StoredProcedure
            'cmd.Parameters.Add(New SqlClient.SqlParameter("@accion", 1))

            Dim read As SqlDataReader = cmd.ExecuteReader()
            listado.Items.Clear()
            If read.HasRows Then
                While read.Read

                    Dim item1 As ListViewItem
                    cadena(0) = CStr(read(0))
                    cadena(1) = CStr(read(1))
                    item1 = New ListViewItem(cadena)

                    listado.Items.Add(item1)
                End While
            Else
                MsgBox("No se han encontrado usuarios")

            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try
    End Function
    Public Function Obtener_Identificacion(ByVal strConexion As String) As DataSet
        Dim ds As New DataSet
        Dim sError As String
        Try
            Cnn = New SqlConnection(strConexion)
            cmd = New SqlCommand("select TipoIdentificacionId,upper(Descripcion) as Descripcion from Cat_TipoIdentificacion ", Cnn)
            cmd.CommandType = CommandType.Text       'asignar tipo de instruccion a ejecutar

            da = New SqlDataAdapter  'crear objeto data adapter
            da.SelectCommand = cmd     'ejecutar objeto command
            da.Fill(ds, "Identificacion")       'llenar dataset
        Catch ex As SqlException
            sError = ex.Number & "-" & ex.Message
        Catch ex As Exception
            sError = ex.Source & "-" & ex.Message
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try
        Return ds
    End Function
    Public Sub CargaDatosUsuario(ByVal Usuario As FrmUsuario, iUserId As Integer)
        Try
            Cnn = New SqlConnection()
            Cnn.ConnectionString = cstrConnectBDapp
            Cnn.Open()
            '
            cmd = Cnn.CreateCommand
            cmd.CommandText = "spCargaDatosUsuarios"
            cmd.CommandType = CommandType.StoredProcedure
            '
            cmd.Parameters.Add(New SqlClient.SqlParameter("@UsuariodId", iUserId))
            '
            With Usuario
                '
                Dim read As SqlDataReader = cmd.ExecuteReader()
                If read.HasRows Then
                    While read.Read
                        .TxtUserId.Text = CStr(read(0))
                        .TxtLogin.Text = CStr(read(1))
                        .TxtLogin.ReadOnly = True
                        .TxtPassword.Text = ""
                        .TxtNombre.Text = CStr(read(3))
                        .LblEstatus.Text = CStr(read(4))
                        .cboPerfil.SelectedValue = CInt(read(5))
                        .chkAdministrador.Checked = CBool(IIf(CInt(read(6)) = 1, True, False))
                        .cboSucursal.SelectedValue = CInt(read(7))
                    End While
                End If
            End With
            '
            cmd.Dispose()
            '
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try

    End Sub
    Public Function Busqueda_ProveedorCliente(ByVal listado As ListView, iTipoCliente As Integer, iTipoProveedorClienteId As Integer) As Boolean
        Busqueda_ProveedorCliente = True
        Dim cadena(16) As String
        Try

            Cnn = New SqlConnection()
            Cnn.ConnectionString = cstrConnectBDapp
            Cnn.Open()
            '
            cmd = Cnn.CreateCommand
            cmd.CommandText = "spListaProveedorCliente"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlClient.SqlParameter("@TipoBusqueda", iTipoCliente))
            cmd.Parameters.Add(New SqlClient.SqlParameter("@TipoProveedorCliente", iTipoProveedorClienteId))

            Dim read As SqlDataReader = cmd.ExecuteReader()
            listado.Items.Clear()
            If read.HasRows Then
                While read.Read

                    Dim item1 As ListViewItem
                    If iTipoCliente = 1 Then
                        cadena(0) = CStr(read(0))
                        cadena(1) = CStr(read(1))
                        cadena(2) = CStr(read(2))
                        cadena(3) = CStr(read(3))
                        cadena(4) = CStr(read(4))
                        cadena(5) = CStr(read(5))
                        cadena(6) = CStr(read(6))
                        cadena(7) = CStr(read(7))
                        cadena(8) = CStr(read(8))
                        cadena(9) = CStr(read(9))
                        cadena(10) = CStr(read(10))
                        cadena(11) = CStr(read(11))
                        cadena(12) = CStr(read(12))
                        cadena(13) = CStr(read(13))
                        cadena(14) = CStr(read(14))
                        cadena(15) = CStr(read(15))
                    Else
                        cadena(0) = CStr(read(0))
                        cadena(1) = CStr(read(1))
                        cadena(2) = CStr(read(2))
                        cadena(3) = CStr(read(3))
                        cadena(4) = CStr(read(4))
                        cadena(5) = CStr(read(5))
                        cadena(6) = CStr(read(6))
                        cadena(7) = CStr(read(7))
                        cadena(8) = CStr(read(8))
                        cadena(9) = CStr(read(9))
                        cadena(10) = CStr(read(10))
                        cadena(11) = CStr(read(11))
                        cadena(12) = CStr(read(12))
                        cadena(13) = CStr(read(13))
                    End If

                    item1 = New ListViewItem(cadena)

                    listado.Items.Add(item1)
                End While
            Else
                If iTipoProveedorClienteId = 1 Then
                    MsgBox("No se han encontrado Proveedores")
                Else
                    MsgBox("No se han encontrado Clientes")
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try
    End Function

    Public Sub CargaDatosProveedorCliente(ByVal Usuario As FrmProveedor, iProveedorId As Integer, iTipo As Integer)
        Try
            Cnn = New SqlConnection()
            Cnn.ConnectionString = cstrConnectBDapp
            Cnn.Open()
            '
            cmd = Cnn.CreateCommand
            cmd.CommandText = "spCargaDatosProveedorCliente"
            cmd.CommandType = CommandType.StoredProcedure
            '
            cmd.Parameters.Add(New SqlClient.SqlParameter("@ProveedorClienteId", iProveedorId))
            '
            With Usuario
                '
                Dim read As SqlDataReader = cmd.ExecuteReader()
                If read.HasRows Then
                    While read.Read
                        If iTipo = 1 Then 'Persona Fisica
                            .txtFolioProveedorCliente.Text = Format(iProveedorId, "000000")
                            .txtNombres.Text = CStr(read(1))
                            .txtApellidos.Text = CStr(read(2))
                            .cboPais.SelectedValue = CInt(read(5))
                            .cboEstado.SelectedValue = CInt(read(6))
                            .cboMunicipio.SelectedValue = CInt(read(7))
                            .cboColonia.SelectedValue = CInt(read(8))
                            .txtCalle.Text = CStr(read(9))
                            .txtNumExterior.Text = CStr(read(10))
                            .txtNuminterior.Text = CStr(read(11))
                            .txtCP.Text = CStr(read(12))
                            .txtTelefono.Text = CStr(read(14))
                            .txtemail.Text = CStr(read(15))
                            .txtRFCPF.Text = CStr(read(18))
                            Select Case CInt(read(19))
                                Case 1
                                    .rbPrecioMayoreo.Checked = True
                                Case 2
                                    .rbPrecioEspecial.Checked = True
                                Case 3
                                    .rbPrecioSuperEspecial.Checked = True
                            End Select
                        Else ' Persona Moral
                            .txtFolioPM.Text = Format(iProveedorId, "000000")
                            .txtRazonSocial.Text = CStr(read(3))
                            .txtRepresentante.Text = CStr(read(4))
                            .cboPaisPM.SelectedValue = CInt(read(5))
                            .cboEstadoPM.SelectedValue = CInt(read(6))
                            .cboPoblacionPM.SelectedValue = CInt(read(7))
                            .cboColoniaPM.SelectedValue = CInt(read(8))
                            .txtCallePM.Text = CStr(read(9))
                            .txtNumeroExteriorPM.Text = CStr(read(10))
                            .txtNumeroInteriorPM.Text = CStr(read(11))
                            .txtCP_PM.Text = CStr(read(12))
                            .txtTelefonoPM.Text = CStr(read(14))
                            .txtemailPM.Text = CStr(read(15))
                            .txtRFC.Text = CStr(read(18))
                            Select Case CInt(read(19))
                                Case 1
                                    .rbPrecioMayoreo.Checked = True
                                Case 2
                                    .rbPrecioEspecial.Checked = True
                                Case 3
                                    .rbPrecioSuperEspecial.Checked = True
                            End Select
                        End If
                    End While
                End If
            End With
            '
            cmd.Dispose()
            '
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try
    End Sub
    Public Function Obtener_TipoVehiculo() As DataSet
        Dim ds As New DataSet
        Dim sError As String
        Try
            Cnn = New SqlConnection(cstrConnectBDapp)
            cmd = New SqlCommand("select TipoVehiculoId,Descripcion from Cat_TipoVehiculo", Cnn)
            cmd.CommandType = CommandType.Text       'asignar tipo de instruccion a ejecutar

            da = New SqlDataAdapter  'crear objeto data adapter
            da.SelectCommand = cmd     'ejecutar objeto command
            da.Fill(ds, "Vehiculo")       'llenar dataset
        Catch ex As SqlException
            sError = ex.Number & "-" & ex.Message
        Catch ex As Exception
            sError = ex.Source & "-" & ex.Message
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try
        Return ds
    End Function
#Region "Funciones y procedimientos Cliente  Persona Fisica"
    Public Function ValidaSinCamposVaciosCliente(ByVal provee As FrmCliente, iTipoProveedorCliente As Integer) As Boolean
        ValidaSinCamposVaciosCliente = True
        Dim faltantes As String = "Los Campos Faltantes son los siguientes:" & vbCrLf

        With provee
            If Trim(.txtNombres.Text) = "" And iTipoProveedorCliente = 1 Then
                ValidaSinCamposVaciosCliente = False
                faltantes &= "-Nombres " & vbCrLf
            End If
            If Trim(.txtApellidos.Text) = "" And iTipoProveedorCliente = 1 Then
                ValidaSinCamposVaciosCliente = False
                faltantes &= "-Apellidos " & vbCrLf
            End If
            '
            If Trim(.txtCalle.Text) = "" And iTipoProveedorCliente = 1 Then
                ValidaSinCamposVaciosCliente = False
                faltantes &= "-Calle " & vbCrLf
            End If
            '
            If Trim(.txtCP.Text) = "" And iTipoProveedorCliente = 1 Then
                ValidaSinCamposVaciosCliente = False
                faltantes &= "-Codigo Postal " & vbCrLf
            End If
            '
            If Trim(.txtRazonSocial.Text) = "" And iTipoProveedorCliente = 2 Then
                ValidaSinCamposVaciosCliente = False
                faltantes &= "-Razon Social " & vbCrLf
            End If
            If Trim(.txtRepresentante.Text) = "" And iTipoProveedorCliente = 2 Then
                ValidaSinCamposVaciosCliente = False
                faltantes &= "-Representante " & vbCrLf
            End If
            If Trim(.txtRFC.Text) = "" And iTipoProveedorCliente = 2 Then
                ValidaSinCamposVaciosCliente = False
                faltantes &= "-R.F.C. " & vbCrLf
            End If
            If Trim(.txtCallePM.Text) = "" And iTipoProveedorCliente = 2 Then
                ValidaSinCamposVaciosCliente = False
                faltantes &= "-Calle " & vbCrLf
            End If
            If Trim(.txtCP_PM.Text) = "" And iTipoProveedorCliente = 2 Then
                ValidaSinCamposVaciosCliente = False
                faltantes &= "-Codigo Postal " & vbCrLf
            End If
            If validar_Mail(.txtemail.Text) = False And iTipoProveedorCliente = 1 Then
                faltantes &= "- Correo incorrecta" & vbCrLf
                ValidaSinCamposVaciosCliente = False
            End If
            If validar_Mail(.txtemailPM.Text) = False And iTipoProveedorCliente = 2 Then
                faltantes &= "- Correo incorrecta" & vbCrLf
                ValidaSinCamposVaciosCliente = False
            End If
        End With

        If ValidaSinCamposVaciosCliente = False Then
            MsgBox(faltantes)
        End If
    End Function
    Public Sub Insertar_Actualizar_Cliente(ByVal Clie As FrmCliente, iAccion As Integer, iTipoProveedorCliente As Integer)
        Dim Transaccion As SqlTransaction = Nothing
        Dim Client As Integer
        Dim iTipoPersona As Integer
        Dim iTipoPrecioId As Integer
        Try
            Cnn = New SqlConnection()
            Cnn.ConnectionString = cstrConnectBDapp
            Cnn.Open()


            With Clie
                Transaccion = Cnn.BeginTransaction
                cmd = Cnn.CreateCommand
                cmd.CommandText = "spABM_ProveedorCliente"
                '
                cmd.CommandType = CommandType.StoredProcedure
                If .txtFolioProveedorCliente.Text.Equals("") And iAccion = 1 Then
                    cmd.Parameters.Add(New SqlClient.SqlParameter("@ProveedorClienteId", 0))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("@accion", 1))
                Else
                    If Trim(.txtFolioProveedorCliente.Text) <> "" And iAccion = 2 Then
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@ProveedorClienteId", .txtFolioProveedorCliente.Text))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@accion", 2))
                    Else
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@ProveedorClienteId", .txtFolioProveedorCliente.Text))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@accion", 3))
                    End If
                End If
                'Tipo Persona
                iTipoPersona = CInt(IIf(.rbPersonaFisica.Checked = True, 1, 2))
                '
                cmd.Parameters.Add(New SqlClient.SqlParameter("@TipoProveedorClienteId", iTipoProveedorCliente))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Nombres", .txtNombres.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Apellidos", .txtApellidos.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@RazonSocial", .txtRazonSocial.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Representante", .txtRepresentante.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@PaisId", IIf(iTipoPersona = 1, .cboPais.SelectedValue, .cboPaisPM.SelectedValue)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@EstadoId", IIf(iTipoPersona = 1, .cboEstado.SelectedValue, .cboEstadoPM.SelectedValue)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@PoblacionId", IIf(iTipoPersona = 1, .cboMunicipio.SelectedValue, .cboPoblacionPM.SelectedValue)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@ColoniaId", IIf(iTipoPersona = 1, .cboColonia.SelectedValue, .cboColoniaPM.SelectedValue)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Calle", IIf(iTipoPersona = 1, .txtCalle.Text, .txtCallePM.Text)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@NumeroExterior", IIf(iTipoPersona = 1, .txtNumExterior.Text, .txtNumeroExteriorPM.Text)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@NumeroInterior", IIf(iTipoPersona = 1, .txtNuminterior.Text, .txtNumeroInteriorPM.Text)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@CP", IIf(iTipoPersona = 1, .txtCP.Text, .txtCP_PM.Text)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Telefono", IIf(iTipoPersona = 1, .txtTelefono.Text, .txtTelefonoPM.Text)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@email", IIf(iTipoPersona = 1, .txtemail.Text, .txtemailPM.Text)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@UsuarioId", iUsuario))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@RFC", IIf(iTipoPersona = 1, Trim(.txtRFCPF.Text), Trim(.txtRFC.Text))))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@TipoPersonaId", iTipoPersona))
                '
                If .rbPrecioMayoreo.Checked Then
                    iTipoPrecioId = 1
                End If
                If .rbPrecioEspecial.Checked Then
                    iTipoPrecioId = 2
                End If
                If .rbPrecioSuperEspecial.Checked Then
                    iTipoPrecioId = 3
                End If
                cmd.Parameters.Add(New SqlClient.SqlParameter("@TipoPrecioId", iTipoPrecioId))
                '
                cmd.Transaction = Transaccion

                If .txtFolioProveedorCliente.Text.Equals("") And iAccion = 1 Then
                    Dim read As SqlDataReader = cmd.ExecuteReader()
                    read.Read()
                    Client = CInt(read(0))
                    MsgBox("Datos de Proveedor-Cliente registrados con exito")
                    read.Close()
                Else
                    If iAccion = 2 Then
                        cmd.ExecuteNonQuery()
                        MsgBox("Datos de Proveedor-Cliente dados de baja con exito")
                    Else
                        cmd.ExecuteNonQuery()
                        MsgBox("Datos de Proveeedor-Cliente actualizado con exito")
                    End If
                End If
            End With

            cmd.Dispose()
            Transaccion.Commit()
            If iAccion = 1 Then
                Clie.txtFolioProveedorCliente.Text = Format(Client, "000000")
            End If
            '
        Catch ex As Exception
            Transaccion.Rollback()
            MsgBox(ex.Message)
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try

    End Sub

    Public Sub CargaDatosCliente(ByVal Usuario As FrmCliente, iClienteId As Integer, iTipo As Integer)
        Try
            Cnn = New SqlConnection()
            Cnn.ConnectionString = cstrConnectBDapp
            Cnn.Open()
            '
            cmd = Cnn.CreateCommand
            cmd.CommandText = "spCargaDatosProveedorCliente"
            cmd.CommandType = CommandType.StoredProcedure
            '
            cmd.Parameters.Add(New SqlClient.SqlParameter("@ProveedorClienteId", iClienteId))
            '
            With Usuario
                '
                Dim read As SqlDataReader = cmd.ExecuteReader()
                If read.HasRows Then
                    While read.Read
                        If iTipo = 1 Then 'Persona Fisica
                            .txtFolioProveedorCliente.Text = Format(iClienteId, "000000")
                            .txtNombres.Text = CStr(read(1))
                            .txtApellidos.Text = CStr(read(2))
                            .cboPais.SelectedValue = CInt(read(5))
                            .cboEstado.SelectedValue = CInt(read(6))
                            .cboMunicipio.SelectedValue = CInt(read(7))
                            .cboColonia.SelectedValue = CInt(read(8))
                            .txtCalle.Text = CStr(read(9))
                            .txtNumExterior.Text = CStr(read(10))
                            .txtNuminterior.Text = CStr(read(11))
                            .txtCP.Text = CStr(read(12))
                            .txtTelefono.Text = CStr(read(14))
                            .txtemail.Text = CStr(read(15))
                            .txtRFCPF.Text = CStr(read(18))
                            Select Case CInt(read(19))
                                Case 1
                                    .rbPrecioMayoreo.Checked = True
                                Case 2
                                    .rbPrecioEspecial.Checked = True
                                Case 3
                                    .rbPrecioSuperEspecial.Checked = True
                            End Select
                        Else ' Persona Moral
                            .txtFolioPM.Text = Format(iClienteId, "000000")
                            .txtRazonSocial.Text = CStr(read(3))
                            .txtRepresentante.Text = CStr(read(4))
                            .cboPaisPM.SelectedValue = CInt(read(5))
                            .cboEstadoPM.SelectedValue = CInt(read(6))
                            .cboPoblacionPM.SelectedValue = CInt(read(7))
                            .cboColoniaPM.SelectedValue = CInt(read(8))
                            .txtCallePM.Text = CStr(read(9))
                            .txtNumeroExteriorPM.Text = CStr(read(10))
                            .txtNumeroInteriorPM.Text = CStr(read(11))
                            .txtCP_PM.Text = CStr(read(12))
                            .txtTelefonoPM.Text = CStr(read(14))
                            .txtemailPM.Text = CStr(read(15))
                            .txtRFC.Text = CStr(read(18))
                            Select Case CInt(read(19))
                                Case 1
                                    .rbPrecioMayoreo.Checked = True
                                Case 2
                                    .rbPrecioEspecial.Checked = True
                                Case 3
                                    .rbPrecioSuperEspecial.Checked = True
                            End Select
                        End If
                    End While
                End If
            End With
            '
            cmd.Dispose()
            '
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try
    End Sub
#End Region
#Region "Funciones y procedimientos Proveedor  Persona Fisica"
    Public Function ValidaSinCamposVacios(ByVal provee As FrmProveedor, iTipoProveedorCliente As Integer) As Boolean
        ValidaSinCamposVacios = True
        Dim faltantes As String = "Los Campos Faltantes son los siguientes:" & vbCrLf

        With provee
            If Trim(.txtNombres.Text) = "" And iTipoProveedorCliente = 1 Then
                ValidaSinCamposVacios = False
                faltantes &= "-Nombres " & vbCrLf
            End If
            If Trim(.txtApellidos.Text) = "" And iTipoProveedorCliente = 1 Then
                ValidaSinCamposVacios = False
                faltantes &= "-Apellidos " & vbCrLf
            End If
            '
            If Trim(.txtCalle.Text) = "" And iTipoProveedorCliente = 1 Then
                ValidaSinCamposVacios = False
                faltantes &= "-Calle " & vbCrLf
            End If
            '
            If Trim(.txtCP.Text) = "" And iTipoProveedorCliente = 1 Then
                ValidaSinCamposVacios = False
                faltantes &= "-Codigo Postal " & vbCrLf
            End If
            '
            If Trim(.txtRazonSocial.Text) = "" And iTipoProveedorCliente = 2 Then
                ValidaSinCamposVacios = False
                faltantes &= "-Razon Social " & vbCrLf
            End If
            If Trim(.txtRepresentante.Text) = "" And iTipoProveedorCliente = 2 Then
                ValidaSinCamposVacios = False
                faltantes &= "-Representante " & vbCrLf
            End If
            If Trim(.txtRFC.Text) = "" And iTipoProveedorCliente = 2 Then
                ValidaSinCamposVacios = False
                faltantes &= "-R.F.C. " & vbCrLf
            End If
            If Trim(.txtCallePM.Text) = "" And iTipoProveedorCliente = 2 Then
                ValidaSinCamposVacios = False
                faltantes &= "-Calle " & vbCrLf
            End If
            If Trim(.txtCP_PM.Text) = "" And iTipoProveedorCliente = 2 Then
                ValidaSinCamposVacios = False
                faltantes &= "-Codigo Postal " & vbCrLf
            End If
            If Trim(.txtemail.Text) <> "" And validar_Mail(.txtemail.Text) = False And iTipoProveedorCliente = 1 Then
                faltantes &= "- Correo incorrecta" & vbCrLf
                ValidaSinCamposVacios = False
            End If
            If Trim(.txtemailPM.Text) <> "" And validar_Mail(.txtemailPM.Text) = False And iTipoProveedorCliente = 2 Then
                faltantes &= "- Correo incorrecta" & vbCrLf
                ValidaSinCamposVacios = False
            End If
        End With

        If ValidaSinCamposVacios = False Then
            MsgBox(faltantes)
        End If
    End Function
    Public Sub Insertar_Actualizar_Proveedor(ByVal Clie As FrmProveedor, iAccion As Integer, iTipoProveedorCliente As Integer)
        Dim Transaccion As SqlTransaction = Nothing
        Dim Client As Integer
        Dim iTipoPersona As Integer
        Dim iTipoPrecioId As Integer
        Try
            Cnn = New SqlConnection()
            Cnn.ConnectionString = cstrConnectBDapp
            Cnn.Open()


            With Clie
                Transaccion = Cnn.BeginTransaction
                cmd = Cnn.CreateCommand
                cmd.CommandText = "spABM_ProveedorCliente"
                '
                cmd.CommandType = CommandType.StoredProcedure
                If .txtFolioProveedorCliente.Text.Equals("") And iAccion = 1 Then
                    cmd.Parameters.Add(New SqlClient.SqlParameter("@ProveedorClienteId", 0))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("@accion", 1))
                Else
                    If Trim(.txtFolioProveedorCliente.Text) <> "" And iAccion = 2 Then
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@ProveedorClienteId", .txtFolioProveedorCliente.Text))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@accion", 2))
                    Else
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@ProveedorClienteId", .txtFolioProveedorCliente.Text))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@accion", 3))
                    End If
                End If
                'Tipo Persona
                iTipoPersona = CInt(IIf(.rbPersonaFisica.Checked = True, 1, 2))
                '
                cmd.Parameters.Add(New SqlClient.SqlParameter("@TipoProveedorClienteId", iTipoProveedorCliente))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Nombres", .txtNombres.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Apellidos", .txtApellidos.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@RazonSocial", .txtRazonSocial.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Representante", .txtRepresentante.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@PaisId", IIf(iTipoPersona = 1, .cboPais.SelectedValue, .cboPaisPM.SelectedValue)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@EstadoId", IIf(iTipoPersona = 1, .cboEstado.SelectedValue, .cboEstadoPM.SelectedValue)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@PoblacionId", IIf(iTipoPersona = 1, .cboMunicipio.SelectedValue, .cboPoblacionPM.SelectedValue)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@ColoniaId", IIf(iTipoPersona = 1, .cboColonia.SelectedValue, .cboColoniaPM.SelectedValue)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Calle", IIf(iTipoPersona = 1, .txtCalle.Text, .txtCallePM.Text)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@NumeroExterior", IIf(iTipoPersona = 1, .txtNumExterior.Text, .txtNumeroExteriorPM.Text)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@NumeroInterior", IIf(iTipoPersona = 1, .txtNuminterior.Text, .txtNumeroInteriorPM.Text)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@CP", IIf(iTipoPersona = 1, .txtCP.Text, .txtCP_PM.Text)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Telefono", IIf(iTipoPersona = 1, .txtTelefono.Text, .txtTelefonoPM.Text)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@email", IIf(iTipoPersona = 1, .txtemail.Text, .txtemailPM.Text)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@UsuarioId", iUsuario))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@RFC", IIf(iTipoPersona = 1, Trim(.txtRFCPF.Text), Trim(.txtRFC.Text))))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@TipoPersonaId", iTipoPersona))
                '
                If .rbPrecioMayoreo.Checked Then
                    iTipoPrecioId = 1
                End If
                If .rbPrecioEspecial.Checked Then
                    iTipoPrecioId = 2
                End If
                If .rbPrecioSuperEspecial.Checked Then
                    iTipoPrecioId = 3
                End If
                cmd.Parameters.Add(New SqlClient.SqlParameter("@TipoPrecioId", iTipoPrecioId))
                '
                cmd.Transaction = Transaccion

                If .txtFolioProveedorCliente.Text.Equals("") And iAccion = 1 Then
                    Dim read As SqlDataReader = cmd.ExecuteReader()
                    read.Read()
                    Client = CInt(read(0))
                    MsgBox("Datos de Proveedor-Cliente registrados con exito")
                    read.Close()
                Else
                    If iAccion = 2 Then
                        cmd.ExecuteNonQuery()
                        MsgBox("Datos de Proveedor-Cliente dados de baja con exito")
                    Else
                        cmd.ExecuteNonQuery()
                        MsgBox("Datos de Proveeedor-Cliente actualizado con exito")
                    End If
                End If
            End With

            cmd.Dispose()
            Transaccion.Commit()
            If iAccion = 1 Then
                Clie.txtFolioProveedorCliente.Text = Format(Client, "000000")
            End If
            '
        Catch ex As Exception
            Transaccion.Rollback()
            MsgBox(ex.Message)
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try

    End Sub
#End Region
#Region "Procedimientos y Funciones de Vehiculos"
    Public Sub Insertar_Actualizar_Vehiculo(ByVal Vehiculo As FrmVehiculos, iAccion As Integer, iProveedorCliente As Integer, iVehiculo As Integer)
        Dim Transaccion As SqlTransaction = Nothing
        Dim iVehiculoNuevo As Integer
        Try
            Cnn = New SqlConnection()
            Cnn.ConnectionString = cstrConnectBDapp
            Cnn.Open()


            With Vehiculo
                Transaccion = Cnn.BeginTransaction
                cmd = Cnn.CreateCommand
                cmd.CommandText = "spAMB_Vehiculos_ProveedorCliente"
                '
                cmd.CommandType = CommandType.StoredProcedure
                If iVehiculo = 0 And iAccion = 1 Then
                    cmd.Parameters.Add(New SqlClient.SqlParameter("@VehiculoId", 0))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("@accion", 1))
                Else
                    If iVehiculo > 0 And iAccion = 2 Then
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@VehiculoId", iVehiculo))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@accion", 2))
                    Else
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@VehiculoId", iVehiculo))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@accion", 3))
                    End If
                End If
                cmd.Parameters.Add(New SqlClient.SqlParameter("@ProveedorClienteId", iProveedorCliente))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@TipoVehiculoId", .cboTipoVehiculo.SelectedValue))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@DescripcionVehiculo", .txtDescripcion.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Placa", .txtPlaca.Text))
                '
                cmd.Transaction = Transaccion

                If iAccion = 1 Then
                    Dim read As SqlDataReader = cmd.ExecuteReader()
                    read.Read()
                    iVehiculoNuevo = CInt(read(0))
                    MsgBox("Datos de Vehiculo registrados con exito")
                    read.Close()
                Else
                    If iAccion = 2 Then
                        cmd.ExecuteNonQuery()
                        MsgBox("Datos de Vehiculo dados de baja con exito")
                    Else
                        cmd.ExecuteNonQuery()
                        MsgBox("Datos de Vehiculo actualizado con exito")
                    End If
                End If
            End With

            cmd.Dispose()
            Transaccion.Commit()
            If iAccion = 1 Then
                Vehiculo.iVehiculoId = iVehiculoNuevo
            End If
            '
        Catch ex As Exception
            Transaccion.Rollback()
            MsgBox(ex.Message)
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try

    End Sub
#End Region
#Region "Procedimientos y Funciones de Productos"
    Public Sub Insertar_Actualizar_Producto(ByVal Prod As FrmProductos, iAccion As Integer)
        Dim Transaccion As SqlTransaction = Nothing
        Dim TempProdId As Integer
        Try
            Cnn = New SqlConnection()
            Cnn.ConnectionString = cstrConnectBDapp
            Cnn.Open()
            '
            With Prod
                Transaccion = Cnn.BeginTransaction
                cmd = Cnn.CreateCommand
                cmd.CommandText = "spABM_Productos"
                '
                cmd.CommandType = CommandType.StoredProcedure
                If .iProductoId = 0 Then
                    cmd.Parameters.Add(New SqlClient.SqlParameter("@ProductoId", 0))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("@accion", 1))
                Else
                    If .iProductoId > 0 And iAccion = 2 Then
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@ProductoId", .iProductoId))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@accion", 2))
                    Else
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@ProductoId", .iProductoId))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@accion", 3))
                    End If
                End If
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Codigo", .txtCodigoProducto.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Nombre", .txtNombre.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Descripcion", .txtDescripcion.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Precio", .txtPrecio.Text))
                'cmd.Parameters.Add(New SqlClient.SqlParameter("@PrecioEspecial", .txtPrecioEspecial.Text))
                'cmd.Parameters.Add(New SqlClient.SqlParameter("@PrecioSuperEspecial", .txtPrecioSuperEspecial.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@UnidadId", .cboUnidad.SelectedValue))
                '
                cmd.Transaction = Transaccion

                If .iProductoId = 0 And iAccion = 1 Then
                    Dim read As SqlDataReader = cmd.ExecuteReader()
                    read.Read()
                    TempProdId = CInt(read(0))
                    MsgBox("Datos de Producto registrados con exito")
                    read.Close()
                Else
                    If iAccion = 2 Then
                        cmd.ExecuteNonQuery()
                        MsgBox("Datos de Producto dados de baja con exito")
                    Else
                        cmd.ExecuteNonQuery()
                        MsgBox("Datos de Producto actualizado con exito")
                    End If
                End If
            End With

            cmd.Dispose()
            Transaccion.Commit()
            If iAccion = 1 Then
                Prod.iProductoId = TempProdId
            End If
            '
        Catch ex As Exception
            Transaccion.Rollback()
            MsgBox(ex.Message)
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try

    End Sub
    Public Function ValidaCamposProducto(ByVal productos As FrmProductos) As Boolean
        ValidaCamposProducto = True
        Dim faltantes As String = "Los Campos Faltantes son los siguientes:" & vbCrLf

        With productos
            If Trim(.txtCodigoProducto.Text) = "" Then
                ValidaCamposProducto = False
                faltantes &= "-Codigo Producto " & vbCrLf
            End If
            If Trim(.txtNombre.Text) = "" Then
                ValidaCamposProducto = False
                faltantes &= "-Nombre " & vbCrLf
            End If
            'If Trim(.txtDescripcion.Text) = "" Then
            '    ValidaCamposProducto = False
            '    faltantes &= "-Descripcion " & vbCrLf
            'End If
            If Trim(.txtPrecio.Text) = "" Then 'Or CDbl(.txtPrecio.Text) <= 0 Then
                ValidaCamposProducto = False
                faltantes &= "-Precio " & vbCrLf
            End If
        End With

        If ValidaCamposProducto = False Then
            MsgBox(faltantes)
        End If
    End Function

    Public Function Obtener_Unidad() As DataSet
        Dim ds As New DataSet
        Dim sError As String
        Try
            Cnn = New SqlConnection(cstrConnectBDapp)
            cmd = New SqlCommand("select UnidadId,Descripcion_Unidad from Cat_Unidad", Cnn)
            cmd.CommandType = CommandType.Text       'asignar tipo de instruccion a ejecutar

            da = New SqlDataAdapter  'crear objeto data adapter
            da.SelectCommand = cmd     'ejecutar objeto command
            da.Fill(ds, "Unidad")       'llenar dataset
        Catch ex As SqlException
            sError = ex.Number & "-" & ex.Message
        Catch ex As Exception
            sError = ex.Source & "-" & ex.Message
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try
        Return ds
    End Function
#End Region
#Region "Procedimientos y funciones de Perfil"
    Public Function ValidaCamposPerfil(ByVal perfil As FrmPerfil) As Boolean
        ValidaCamposPerfil = True
        Dim faltantes As String = "Los Campos Faltantes son los siguientes:" & vbCrLf

        With perfil
            If Trim(.txtCodigo.Text) = "" Then
                ValidaCamposPerfil = False
                faltantes &= "-Codigo Perfil " & vbCrLf
            End If
            If Trim(.txtDescripcionPerfil.Text) = "" Then
                ValidaCamposPerfil = False
                faltantes &= "-Descripcion " & vbCrLf
            End If

        End With

        If ValidaCamposPerfil = False Then
            MsgBox(faltantes)
        End If
    End Function
    Public Sub Insertar_Actualizar_Perfil(ByVal Perfil As FrmPerfil, iAccion As Integer)
        Dim Transaccion As SqlTransaction = Nothing
        Dim TempPerfilId As Integer
        Try
            Cnn = New SqlConnection()
            Cnn.ConnectionString = cstrConnectBDapp
            Cnn.Open()
            '
            With Perfil
                Transaccion = Cnn.BeginTransaction
                cmd = Cnn.CreateCommand
                cmd.CommandText = "spABM_Perfil"
                '
                cmd.CommandType = CommandType.StoredProcedure
                If .iPerfilId = 0 Then
                    cmd.Parameters.Add(New SqlClient.SqlParameter("@GrupoID", 0))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("@accion", 1))
                Else
                    If .iPerfilId > 0 And iAccion = 2 Then
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@GrupoID", .iPerfilId))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@accion", 2))
                    Else
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@GrupoID", .iPerfilId))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@accion", 3))
                    End If
                End If
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Grupo", .txtCodigo.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@DescGrupo", .txtDescripcionPerfil.Text))
                '
                cmd.Transaction = Transaccion

                If .iPerfilId = 0 And iAccion = 1 Then
                    Dim read As SqlDataReader = cmd.ExecuteReader()
                    read.Read()
                    TempPerfilId = CInt(read(0))
                    MsgBox("Datos de Perfil registrados con exito")
                    read.Close()
                Else
                    If iAccion = 2 Then
                        cmd.ExecuteNonQuery()
                        MsgBox("Datos de Perfil dados de baja con exito")
                    Else
                        cmd.ExecuteNonQuery()
                        MsgBox("Datos de Perfil actualizado con exito")
                    End If
                End If
            End With

            cmd.Dispose()
            Transaccion.Commit()
            If iAccion = 1 Then
                Perfil.iPerfilId = TempPerfilId
            End If
            '
        Catch ex As Exception
            Transaccion.Rollback()
            MsgBox(ex.Message)
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try

    End Sub
#End Region
    Public Function validar_Mail(ByVal sMail As String) As Boolean
        Dim pattern As String = "^[a-zA-Z][\w\.-]*[a-zA-Z0-9]@" & _
"[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\." & _
"[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$"


        Dim miTextoMatch As Match = Regex.Match(sMail, pattern)

        Return miTextoMatch.Success
    End Function
    Public Function ValidaPerfil(ByVal iUsuarioId As Integer, sPantalla As String) As Boolean
        ValidaPerfil = True
        Dim Transaccion As SqlTransaction = Nothing
        Dim iValida As Integer = 0
        Try
            Cnn = New SqlConnection()
            Cnn.ConnectionString = cstrConnectBDapp
            Cnn.Open()
            '
            Transaccion = Cnn.BeginTransaction
            cmd = Cnn.CreateCommand
            cmd.CommandText = "spValidaPerfil"
            '
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlClient.SqlParameter("@UsuarioId", iUsuarioId))
            cmd.Parameters.Add(New SqlClient.SqlParameter("@Pantalla", sPantalla))
            '
            cmd.Transaction = Transaccion


            Dim read As SqlDataReader = cmd.ExecuteReader()
            read.Read()
            iValida = CInt(read(0))
            '
            read.Close()
            '
            cmd.Dispose()
            Transaccion.Commit()
            If iValida = 0 Then
                ValidaPerfil = False
            End If
            '
        Catch ex As Exception
            Transaccion.Rollback()
            MsgBox(ex.Message)
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try
    End Function

#Region "Procedimientos y Funciones de Permisos"
    Public Sub Insertar_Actualizar_Permisos(ByVal iPerfilId As Integer, XML As String)
        Dim Transaccion As SqlTransaction = Nothing
        '
        Try
            Cnn = New SqlConnection()
            Cnn.ConnectionString = cstrConnectBDapp
            Cnn.Open()
            '
            Transaccion = Cnn.BeginTransaction
            cmd = Cnn.CreateCommand
            cmd.CommandText = "spABM_Permisos"
            '
            cmd.CommandType = CommandType.StoredProcedure
            '
            cmd.Parameters.Add(New SqlClient.SqlParameter("@XML_Clie", XML))
            cmd.Parameters.Add(New SqlClient.SqlParameter("@GrupoID", iPerfilId))
            '
            '
            cmd.Transaction = Transaccion
            '
            cmd.ExecuteNonQuery()
            MsgBox("Datos de Permiso actualizado con exito")
            '
            cmd.Dispose()
            Transaccion.Commit()
            '
        Catch ex As Exception
            Transaccion.Rollback()
            MsgBox(ex.Message)
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try
    End Sub
#End Region
#Region "Procedimientos y funciones de Pantallas"
    Public Function ValidaCamposPantalla(ByVal pantalla As FrmPantalla) As Boolean
        ValidaCamposPantalla = True
        Dim faltantes As String = "Los Campos Faltantes son los siguientes:" & vbCrLf

        With pantalla
            If Trim(.txtCodigoPantalla.Text) = "" Then
                ValidaCamposPantalla = False
                faltantes &= "-Modulo Pantalla " & vbCrLf
            End If
            If Trim(.txtNombrePantalla.Text) = "" Then
                ValidaCamposPantalla = False
                faltantes &= "-Descripcion Pantalla " & vbCrLf
            End If
            If Trim(.txtPantalla.Text) = "" Then
                ValidaCamposPantalla = False
                faltantes &= "-Codigo Pantalla " & vbCrLf
            End If
            If Trim(.txtLigaPantalla.Text) = "" Then
                ValidaCamposPantalla = False
                faltantes &= "-Liga Pantalla " & vbCrLf
            End If
        End With

        If ValidaCamposPantalla = False Then
            MsgBox(faltantes)
        End If
    End Function
    Public Sub Insertar_Actualizar_Pantalla(ByVal Pantalla As FrmPantalla, iAccion As Integer)
        Dim Transaccion As SqlTransaction = Nothing
        Try
            Cnn = New SqlConnection()
            Cnn.ConnectionString = cstrConnectBDapp
            Cnn.Open()
            '
            With Pantalla
                Transaccion = Cnn.BeginTransaction
                cmd = Cnn.CreateCommand
                cmd.CommandText = "spABM_Pantallas"
                '
                cmd.CommandType = CommandType.StoredProcedure
                If iAccion = 1 Then
                    cmd.Parameters.Add(New SqlClient.SqlParameter("@Accion", 1))
                Else
                    cmd.Parameters.Add(New SqlClient.SqlParameter("@Accion", 3))
                End If
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Modulo", .txtCodigoPantalla.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Nombre", .txtNombrePantalla.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Pantalla", .txtPantalla.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@TipoPantalla", .cboTipoPantalla.SelectedItem))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@LigaPantalla", .txtLigaPantalla.Text))
                '
                cmd.Transaction = Transaccion
                '
                cmd.ExecuteNonQuery()
                If iAccion = 1 Then
                    MsgBox("Datos de Pantalla registrados con exito")
                Else
                    MsgBox("Datos de Pantalla actualizados con exito")
                End If
            End With
            '
            cmd.Dispose()
            Transaccion.Commit()
            '
        Catch ex As Exception
            Transaccion.Rollback()
            MsgBox(ex.Message)
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try

    End Sub
#End Region

#Region "Procedimientos y funciones de Busqueda condicionada"
    Public Function BusquedaCondicionada(ByVal listado As ListView, iTipoCliente As Integer, iTipoProveedorClienteId As Integer) As Boolean
        BusquedaCondicionada = True
        Dim cadena(16) As String
        Try

            Cnn = New SqlConnection()
            Cnn.ConnectionString = cstrConnectBDapp
            Cnn.Open()
            '
            cmd = Cnn.CreateCommand
            cmd.CommandText = "spListaProveedorClienteCondicionado"
            cmd.CommandType = CommandType.StoredProcedure
            cmd.Parameters.Add(New SqlClient.SqlParameter("@TipoClienteId", iTipoCliente))
            cmd.Parameters.Add(New SqlClient.SqlParameter("@iFolio", iFoliobusqueda))
            cmd.Parameters.Add(New SqlClient.SqlParameter("@Nombres", sNombresbusqueda))
            cmd.Parameters.Add(New SqlClient.SqlParameter("@Apellidos", sApellidosbusqueda))
            cmd.Parameters.Add(New SqlClient.SqlParameter("@RazonSocial", sRazonSocialbusqueda))
            cmd.Parameters.Add(New SqlClient.SqlParameter("@TipoProveedorClienteId", iTipoProveedorClienteId))

            Dim read As SqlDataReader = cmd.ExecuteReader()
            listado.Items.Clear()
            If read.HasRows Then
                While read.Read

                    Dim item1 As ListViewItem
                    If iTipoCliente = 1 Then
                        cadena(0) = CStr(read(0))
                        cadena(1) = CStr(read(1))
                        cadena(2) = CStr(read(2))
                        cadena(3) = CStr(read(3))
                        cadena(4) = CStr(read(4))
                        cadena(5) = CStr(read(5))
                        cadena(6) = CStr(read(6))
                        cadena(7) = CStr(read(7))
                        cadena(8) = CStr(read(8))
                        cadena(9) = CStr(read(9))
                        cadena(10) = CStr(read(10))
                        cadena(11) = CStr(read(11))
                        cadena(12) = CStr(read(12))
                        cadena(13) = CStr(read(13))
                        cadena(14) = CStr(read(14))
                        cadena(15) = CStr(read(15))
                    Else
                        cadena(0) = CStr(read(0))
                        cadena(1) = CStr(read(1))
                        cadena(2) = CStr(read(2))
                        cadena(3) = CStr(read(3))
                        cadena(4) = CStr(read(4))
                        cadena(5) = CStr(read(5))
                        cadena(6) = CStr(read(6))
                        cadena(7) = CStr(read(7))
                        cadena(8) = CStr(read(8))
                        cadena(9) = CStr(read(9))
                        cadena(10) = CStr(read(10))
                        cadena(11) = CStr(read(11))
                        cadena(12) = CStr(read(12))
                        cadena(13) = CStr(read(13))
                    End If

                    item1 = New ListViewItem(cadena)

                    listado.Items.Add(item1)
                End While
            Else
                If iTipoProveedorClienteId = 2 Then
                    MsgBox("No se han encontrado Clientes")
                Else
                    MsgBox("No se han encontrado Proveedores")
                End If

            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try
    End Function
#End Region

#Region "Procedimientos y funciones de Pesaje"
    Public Function Obtener_Proveedor(ByVal strConexion As String) As DataSet
        Dim ds As New DataSet
        Dim sError As String
        Try
            Cnn = New SqlConnection(strConexion)
            cmd = New SqlCommand("Select ProveedorClienteid,(case when tipopersonaid = 1 then Nombres + ' ' + Apellidos else RazonSocial end) as NombreProveedor from Proveedor_Cliente where TipoProveedorClienteId = 1 and EstatusId = 1 order by NombreProveedor", Cnn)
            cmd.CommandType = CommandType.Text       'asignar tipo de instruccion a ejecutar

            da = New SqlDataAdapter  'crear objeto data adapter
            da.SelectCommand = cmd     'ejecutar objeto command
            da.Fill(ds, "Proveedor")       'llenar dataset
        Catch ex As SqlException
            sError = ex.Number & "-" & ex.Message
        Catch ex As Exception
            sError = ex.Source & "-" & ex.Message
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try
        Return ds
    End Function
    '
    Public Function Obtener_Material(ByVal strConexion As String) As DataSet
        Dim ds As New DataSet
        Dim sError As String
        Try
            Cnn = New SqlConnection(strConexion)
            cmd = New SqlCommand("Select ProductoId,Descripcion from Productos where Estatusid = 1 order by Descripcion", Cnn)
            cmd.CommandType = CommandType.Text       'asignar tipo de instruccion a ejecutar

            da = New SqlDataAdapter  'crear objeto data adapter
            da.SelectCommand = cmd     'ejecutar objeto command
            da.Fill(ds, "Material")       'llenar dataset
        Catch ex As SqlException
            sError = ex.Number & "-" & ex.Message
        Catch ex As Exception
            sError = ex.Source & "-" & ex.Message
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try
        Return ds
    End Function
    Public Function Obtener_Vehiculos_Proveedor(ByVal strConexion As String, iProveedorId As Integer) As DataSet
        Dim ds As New DataSet
        Dim sError As String
        Try
            Cnn = New SqlConnection(strConexion)
            cmd = New SqlCommand("Select B.VehiculoId,C.Descripcion " & _
                                 "from ProveedorCliente_Vehiculo A " & _
                                 "inner Join Vehiculo_Detalle B On (A.VehiculoId = B.VehiculoId) " & _
                                 "Inner Join Cat_TipoVehiculo C On (B.TipoVehiculoId = C.TipoVehiculoId) " & _
                                 "Where A.ProveedorClienteId =" & iProveedorId, Cnn)
            cmd.CommandType = CommandType.Text       'asignar tipo de instruccion a ejecutar

            da = New SqlDataAdapter  'crear objeto data adapter
            da.SelectCommand = cmd     'ejecutar objeto command
            da.Fill(ds, "Vehiculos")       'llenar dataset
        Catch ex As SqlException
            sError = ex.Number & "-" & ex.Message
        Catch ex As Exception
            sError = ex.Source & "-" & ex.Message
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try
        Return ds
    End Function
    Public Function Obtener_Placa(ByVal strConexion As String, iVehiculoId As Integer, iProveedorId As Integer) As String
        Try
            Cnn = New SqlConnection(strConexion)
            cmd = New SqlCommand("spObtenerPlacaVehiculo", Cnn)
            cmd.CommandType = CommandType.StoredProcedure       'asignar tipo de instruccion a ejecutar
            '
            With cmd
                '
                param = New SqlParameter("@VehiculoId", SqlDbType.Int)
                param.Direction = ParameterDirection.Input      'parametro entrada
                param.Value = iVehiculoId                           '
                .Parameters.Add(param)
                '
                param = New SqlParameter("@ProveedorId", SqlDbType.Int)
                param.Direction = ParameterDirection.Input      'parametro entrada
                param.Value = iProveedorId                           '
                .Parameters.Add(param)
                '
                param = New SqlParameter("@Placa", SqlDbType.VarChar, 50)
                param.Direction = ParameterDirection.Output      'parametro Salida
                .Parameters.Add(param)
                '
                Cnn.Open()
                .ExecuteNonQuery()
                Obtener_Placa = CStr(.Parameters("@Placa").Value)
            End With
        Catch ex As SqlException
            'sError = ex.Number & "-" & ex.Message
            MsgBox(ex.Number & "-" & ex.Message)
        Catch ex As Exception
            'sError = ex.Source & "-" & ex.Message
            MsgBox(ex.Source & "-" & ex.Message)
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try
    End Function

    'Public Sub GuardarProveedorPesaje(ByVal Pesaje As frmPesaje, iAccion As Integer, iActiva As Integer)
    '    Dim Transaccion As SqlTransaction = Nothing
    '    Dim XML As String = ""
    '    Dim ProveedorId As Integer
    '    Dim iEntradaId As Integer = 0
    '    Try
    '        Cnn = New SqlConnection()
    '        Cnn.ConnectionString = cstrConnectBDapp
    '        Cnn.Open()
    '        '
    '        '
    '        With Pesaje
    '            Transaccion = Cnn.BeginTransaction
    '            cmd = Cnn.CreateCommand
    '            cmd.CommandText = "spAltaPesajeProveedor"
    '            '
    '            cmd.CommandType = CommandType.StoredProcedure
    '            '
    '            Select Case iActiva
    '                Case 1
    '                    ProveedorId = CInt(Mid(.cmdTab1.Text, 1, 6))
    '                Case 2
    '                    ProveedorId = CInt(Mid(.cmdTab2.Text, 1, 6))
    '                Case 3
    '                    ProveedorId = CInt(Mid(.cmdTab3.Text, 1, 6))
    '                Case 4
    '                    ProveedorId = CInt(Mid(.cmdTab4.Text, 1, 6))
    '                Case 5
    '                    ProveedorId = CInt(Mid(.cmdTab5.Text, 1, 6))
    '                Case 6
    '                    ProveedorId = CInt(Mid(.cmdTab6.Text, 1, 6))
    '                Case 7
    '                    ProveedorId = CInt(Mid(.cmdTab7.Text, 1, 6))
    '                Case 8
    '                    ProveedorId = CInt(Mid(.cmdTab8.Text, 1, 6))
    '                Case 9
    '                    ProveedorId = CInt(Mid(.cmdTab9.Text, 1, 6))
    '                Case 10
    '                    ProveedorId = CInt(Mid(.cmdTab10.Text, 1, 6))
    '                Case 11
    '                    ProveedorId = CInt(Mid(.cmdTab11.Text, 1, 6))
    '                Case 12
    '                    ProveedorId = CInt(Mid(.cmdTab12.Text, 1, 6))
    '                Case 13
    '                    ProveedorId = CInt(Mid(.cmdTab13.Text, 1, 6))
    '                Case 14
    '                    ProveedorId = CInt(Mid(.cmdTab14.Text, 1, 6))
    '                    'Case 15
    '                    '    ProveedorId = CInt(Mid(.cmdTab15.Text, 1, 6))
    '            End Select
    '            '
    '            XML = "<?xml version=" & Chr(34) & "1.0" & Chr(34) & " encoding=" & Chr(34) & "ISO-8859-1" & Chr(34) & "?>" & vbCrLf
    '            XML &= "<Material>" & vbCrLf
    '            XML &= Genera_DetalleMateriales_XML("Materiales", Pesaje, iActiva)
    '            XML &= "</Material>"
    '            '
    '            cmd.Parameters.Add(New SqlClient.SqlParameter("@ProveedorId", ProveedorId))
    '            cmd.Parameters.Add(New SqlClient.SqlParameter("@XML_Material", XML))
    '            '
    '            cmd.Parameters.Add(New SqlClient.SqlParameter("@UsuarioId", iUsuario))
    '            '
    '            cmd.Transaction = Transaccion
    '            '
    '            Dim read As SqlDataReader = cmd.ExecuteReader()
    '            read.Read()
    '            iEntradaId = CInt(read(0))
    '            read.Close()
    '            '
    '            'cmd.ExecuteNonQuery()
    '            MsgBox("Datos insertados correctamente")
    '            '
    '            Select Case iActiva
    '                Case 1
    '                    .LblEntradaId1.Text = CStr(iEntradaId)
    '                Case 2
    '                    .LblEntradaId2.Text = CStr(iEntradaId)
    '                Case 3
    '                    .LblEntradaId3.Text = CStr(iEntradaId)
    '                Case 4
    '                    .LblEntradaId4.Text = CStr(iEntradaId)
    '                Case 5
    '                    .LblEntradaId5.Text = CStr(iEntradaId)
    '                Case 6
    '                    .lblEntradaId6.Text = CStr(iEntradaId)
    '                Case 7
    '                    .lblEntradaId7.Text = CStr(iEntradaId)
    '                Case 8
    '                    .lblEntradaId8.Text = CStr(iEntradaId)
    '                Case 9
    '                    .lblEntradaId9.Text = CStr(iEntradaId)
    '                Case 10
    '                    .lblEntradaId10.Text = CStr(iEntradaId)
    '                Case 11
    '                    .lblEntradaId11.Text = CStr(iEntradaId)
    '                Case 12
    '                    .lblEntradaId12.Text = CStr(iEntradaId)
    '                Case 13
    '                    .lblEntradaId13.Text = CStr(iEntradaId)
    '                Case 14
    '                    .lblEntradaId14.Text = CStr(iEntradaId)
    '            End Select
    '        End With
    '        '
    '        cmd.Dispose()
    '        Transaccion.Commit()
    '        '
    '    Catch ex As Exception
    '        Transaccion.Rollback()
    '        MsgBox(ex.Message)
    '    Finally
    '        If Not Cnn Is Nothing Then
    '            If Cnn.State = ConnectionState.Open Then
    '                Cnn.Close()    'cerrar conexion
    '                Cnn = Nothing     'destruir objeto
    '            End If
    '        End If
    '    End Try

    'End Sub
    'Private Function Genera_DetalleMateriales_XML(ByVal Tabla As String, ByVal Pesaje As frmPesaje, TabActiva As Integer) As String
    '    Dim str_XML As String = ""
    '    Dim i As Int16
    '    Dim campo As String, valor As String
    '    '
    '    With Pesaje
    '        Select Case TabActiva
    '            Case 1
    '                For i = 0 To CShort(.lvwPesaje1.Items.Count - 1)
    '                    If i > 0 Then
    '                        str_XML &= vbCrLf & "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
    '                    Else
    '                        str_XML &= "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
    '                    End If
    '                    For j = 0 To .lvwPesaje1.Columns.Count - 1
    '                        campo = .lvwPesaje1.Columns.Item(j).Text
    '                        'And campo <> "Kilos"
    '                        If campo <> "Vehículo" And campo <> "Material" Then
    '                            valor = CStr(IIf(.lvwPesaje1.Items.Item(i).SubItems(j).Text Is DBNull.Value, "", .lvwPesaje1.Items.Item(i).SubItems(j).Text))
    '                            '
    '                            str_XML &= vbTab & campo & "=" & Chr(34) & valor & Chr(34) & vbCrLf
    '                            '
    '                        End If
    '                    Next
    '                    str_XML &= "/>"
    '                Next
    '                Return str_XML
    '            Case 2
    '                For i = 0 To CShort(.lvwPesaje2.Items.Count - 1)
    '                    If i > 0 Then
    '                        str_XML &= vbCrLf & "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
    '                    Else
    '                        str_XML &= "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
    '                    End If
    '                    For j = 0 To .lvwPesaje2.Columns.Count - 1
    '                        campo = .lvwPesaje2.Columns.Item(j).Text
    '                        If campo <> "Vehículo" And campo <> "Material" And campo <> "Kilos" Then
    '                            valor = CStr(IIf(.lvwPesaje2.Items.Item(i).SubItems(j).Text Is DBNull.Value, "", .lvwPesaje2.Items.Item(i).SubItems(j).Text))
    '                            '
    '                            str_XML &= vbTab & campo & "=" & Chr(34) & valor & Chr(34) & vbCrLf
    '                            '
    '                        End If
    '                    Next
    '                    str_XML &= "/>"
    '                Next
    '                Return str_XML
    '            Case 3
    '                For i = 0 To CShort(.lvwPesaje3.Items.Count - 1)
    '                    If i > 0 Then
    '                        str_XML &= vbCrLf & "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
    '                    Else
    '                        str_XML &= "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
    '                    End If
    '                    For j = 0 To .lvwPesaje3.Columns.Count - 1
    '                        campo = .lvwPesaje3.Columns.Item(j).Text
    '                        If campo <> "Vehículo" And campo <> "Material" And campo <> "Kilos" Then
    '                            valor = CStr(IIf(.lvwPesaje3.Items.Item(i).SubItems(j).Text Is DBNull.Value, "", .lvwPesaje3.Items.Item(i).SubItems(j).Text))
    '                            '
    '                            str_XML &= vbTab & campo & "=" & Chr(34) & valor & Chr(34) & vbCrLf
    '                            '
    '                        End If
    '                    Next
    '                    str_XML &= "/>"
    '                Next
    '                Return str_XML
    '            Case 4
    '                For i = 0 To CShort(.lvwPesaje4.Items.Count - 1)
    '                    If i > 0 Then
    '                        str_XML &= vbCrLf & "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
    '                    Else
    '                        str_XML &= "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
    '                    End If
    '                    For j = 0 To .lvwPesaje4.Columns.Count - 1
    '                        campo = .lvwPesaje4.Columns.Item(j).Text
    '                        If campo <> "Vehículo" And campo <> "Material" And campo <> "Kilos" Then
    '                            valor = CStr(IIf(.lvwPesaje4.Items.Item(i).SubItems(j).Text Is DBNull.Value, "", .lvwPesaje4.Items.Item(i).SubItems(j).Text))
    '                            '
    '                            str_XML &= vbTab & campo & "=" & Chr(34) & valor & Chr(34) & vbCrLf
    '                            '
    '                        End If
    '                    Next
    '                    str_XML &= "/>"
    '                Next
    '                Return str_XML
    '            Case 5
    '                For i = 0 To CShort(.lvwPesaje5.Items.Count - 1)
    '                    If i > 0 Then
    '                        str_XML &= vbCrLf & "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
    '                    Else
    '                        str_XML &= "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
    '                    End If
    '                    For j = 0 To .lvwPesaje5.Columns.Count - 1
    '                        campo = .lvwPesaje5.Columns.Item(j).Text
    '                        If campo <> "Vehículo" And campo <> "Material" And campo <> "Kilos" Then
    '                            valor = CStr(IIf(.lvwPesaje5.Items.Item(i).SubItems(j).Text Is DBNull.Value, "", .lvwPesaje5.Items.Item(i).SubItems(j).Text))
    '                            '
    '                            str_XML &= vbTab & campo & "=" & Chr(34) & valor & Chr(34) & vbCrLf
    '                            '
    '                        End If
    '                    Next
    '                    str_XML &= "/>"
    '                Next
    '                Return str_XML
    '            Case 6
    '                For i = 0 To CShort(.lvwPesaje6.Items.Count - 1)
    '                    If i > 0 Then
    '                        str_XML &= vbCrLf & "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
    '                    Else
    '                        str_XML &= "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
    '                    End If
    '                    For j = 0 To .lvwPesaje6.Columns.Count - 1
    '                        campo = .lvwPesaje6.Columns.Item(j).Text
    '                        If campo <> "Vehículo" And campo <> "Material" And campo <> "Kilos" Then
    '                            valor = CStr(IIf(.lvwPesaje6.Items.Item(i).SubItems(j).Text Is DBNull.Value, "", .lvwPesaje6.Items.Item(i).SubItems(j).Text))
    '                            '
    '                            str_XML &= vbTab & campo & "=" & Chr(34) & valor & Chr(34) & vbCrLf
    '                            '
    '                        End If
    '                    Next
    '                    str_XML &= "/>"
    '                Next
    '                Return str_XML
    '            Case 7
    '                For i = 0 To CShort(.lvwPesaje7.Items.Count - 1)
    '                    If i > 0 Then
    '                        str_XML &= vbCrLf & "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
    '                    Else
    '                        str_XML &= "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
    '                    End If
    '                    For j = 0 To .lvwPesaje7.Columns.Count - 1
    '                        campo = .lvwPesaje7.Columns.Item(j).Text
    '                        If campo <> "Vehículo" And campo <> "Material" And campo <> "Kilos" Then
    '                            valor = CStr(IIf(.lvwPesaje7.Items.Item(i).SubItems(j).Text Is DBNull.Value, "", .lvwPesaje7.Items.Item(i).SubItems(j).Text))
    '                            '
    '                            str_XML &= vbTab & campo & "=" & Chr(34) & valor & Chr(34) & vbCrLf
    '                            '
    '                        End If
    '                    Next
    '                    str_XML &= "/>"
    '                Next
    '                Return str_XML
    '            Case 8
    '                For i = 0 To CShort(.lvwPesaje8.Items.Count - 1)
    '                    If i > 0 Then
    '                        str_XML &= vbCrLf & "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
    '                    Else
    '                        str_XML &= "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
    '                    End If
    '                    For j = 0 To .lvwPesaje8.Columns.Count - 1
    '                        campo = .lvwPesaje8.Columns.Item(j).Text
    '                        If campo <> "Vehículo" And campo <> "Material" And campo <> "Kilos" Then
    '                            valor = CStr(IIf(.lvwPesaje8.Items.Item(i).SubItems(j).Text Is DBNull.Value, "", .lvwPesaje8.Items.Item(i).SubItems(j).Text))
    '                            '
    '                            str_XML &= vbTab & campo & "=" & Chr(34) & valor & Chr(34) & vbCrLf
    '                            '
    '                        End If
    '                    Next
    '                    str_XML &= "/>"
    '                Next
    '                Return str_XML
    '            Case 9
    '                For i = 0 To CShort(.lvwPesaje9.Items.Count - 1)
    '                    If i > 0 Then
    '                        str_XML &= vbCrLf & "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
    '                    Else
    '                        str_XML &= "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
    '                    End If
    '                    For j = 0 To .lvwPesaje9.Columns.Count - 1
    '                        campo = .lvwPesaje9.Columns.Item(j).Text
    '                        If campo <> "Vehículo" And campo <> "Material" And campo <> "Kilos" Then
    '                            valor = CStr(IIf(.lvwPesaje9.Items.Item(i).SubItems(j).Text Is DBNull.Value, "", .lvwPesaje9.Items.Item(i).SubItems(j).Text))
    '                            '
    '                            str_XML &= vbTab & campo & "=" & Chr(34) & valor & Chr(34) & vbCrLf
    '                            '
    '                        End If
    '                    Next
    '                    str_XML &= "/>"
    '                Next
    '                Return str_XML
    '            Case 10
    '                For i = 0 To CShort(.lvwPesaje10.Items.Count - 1)
    '                    If i > 0 Then
    '                        str_XML &= vbCrLf & "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
    '                    Else
    '                        str_XML &= "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
    '                    End If
    '                    For j = 0 To .lvwPesaje10.Columns.Count - 1
    '                        campo = .lvwPesaje10.Columns.Item(j).Text
    '                        If campo <> "Vehículo" And campo <> "Material" And campo <> "Kilos" Then
    '                            valor = CStr(IIf(.lvwPesaje10.Items.Item(i).SubItems(j).Text Is DBNull.Value, "", .lvwPesaje10.Items.Item(i).SubItems(j).Text))
    '                            '
    '                            str_XML &= vbTab & campo & "=" & Chr(34) & valor & Chr(34) & vbCrLf
    '                            '
    '                        End If
    '                    Next
    '                    str_XML &= "/>"
    '                Next
    '                Return str_XML
    '            Case 11
    '                For i = 0 To CShort(.lvwPesaje11.Items.Count - 1)
    '                    If i > 0 Then
    '                        str_XML &= vbCrLf & "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
    '                    Else
    '                        str_XML &= "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
    '                    End If
    '                    For j = 0 To .lvwPesaje11.Columns.Count - 1
    '                        campo = .lvwPesaje11.Columns.Item(j).Text
    '                        If campo <> "Vehículo" And campo <> "Material" And campo <> "Kilos" Then
    '                            valor = CStr(IIf(.lvwPesaje11.Items.Item(i).SubItems(j).Text Is DBNull.Value, "", .lvwPesaje11.Items.Item(i).SubItems(j).Text))
    '                            '
    '                            str_XML &= vbTab & campo & "=" & Chr(34) & valor & Chr(34) & vbCrLf
    '                            '
    '                        End If
    '                    Next
    '                    str_XML &= "/>"
    '                Next
    '                Return str_XML
    '            Case 12
    '                For i = 0 To CShort(.lvwPesaje12.Items.Count - 1)
    '                    If i > 0 Then
    '                        str_XML &= vbCrLf & "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
    '                    Else
    '                        str_XML &= "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
    '                    End If
    '                    For j = 0 To .lvwPesaje12.Columns.Count - 1
    '                        campo = .lvwPesaje12.Columns.Item(j).Text
    '                        If campo <> "Vehículo" And campo <> "Material" And campo <> "Kilos" Then
    '                            valor = CStr(IIf(.lvwPesaje12.Items.Item(i).SubItems(j).Text Is DBNull.Value, "", .lvwPesaje12.Items.Item(i).SubItems(j).Text))
    '                            '
    '                            str_XML &= vbTab & campo & "=" & Chr(34) & valor & Chr(34) & vbCrLf
    '                            '
    '                        End If
    '                    Next
    '                    str_XML &= "/>"
    '                Next
    '                Return str_XML
    '            Case 13
    '                For i = 0 To CShort(.lvwPesaje13.Items.Count - 1)
    '                    If i > 0 Then
    '                        str_XML &= vbCrLf & "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
    '                    Else
    '                        str_XML &= "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
    '                    End If
    '                    For j = 0 To .lvwPesaje13.Columns.Count - 1
    '                        campo = .lvwPesaje13.Columns.Item(j).Text
    '                        If campo <> "Vehículo" And campo <> "Material" And campo <> "Kilos" Then
    '                            valor = CStr(IIf(.lvwPesaje13.Items.Item(i).SubItems(j).Text Is DBNull.Value, "", .lvwPesaje13.Items.Item(i).SubItems(j).Text))
    '                            '
    '                            str_XML &= vbTab & campo & "=" & Chr(34) & valor & Chr(34) & vbCrLf
    '                            '
    '                        End If
    '                    Next
    '                    str_XML &= "/>"
    '                Next
    '                Return str_XML
    '            Case 14
    '                For i = 0 To CShort(.lvwPesaje14.Items.Count - 1)
    '                    If i > 0 Then
    '                        str_XML &= vbCrLf & "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
    '                    Else
    '                        str_XML &= "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
    '                    End If
    '                    For j = 0 To .lvwPesaje14.Columns.Count - 1
    '                        campo = .lvwPesaje14.Columns.Item(j).Text
    '                        If campo <> "Vehículo" And campo <> "Material" And campo <> "Kilos" Then
    '                            valor = CStr(IIf(.lvwPesaje14.Items.Item(i).SubItems(j).Text Is DBNull.Value, "", .lvwPesaje14.Items.Item(i).SubItems(j).Text))
    '                            '
    '                            str_XML &= vbTab & campo & "=" & Chr(34) & valor & Chr(34) & vbCrLf
    '                            '
    '                        End If
    '                    Next
    '                    str_XML &= "/>"
    '                Next
    '                Return str_XML
    '                'Case 15
    '                '    For i = 0 To CShort(.lvwPesaje15.Items.Count - 1)
    '                '        If i > 0 Then
    '                '            str_XML &= vbCrLf & "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
    '                '        Else
    '                '            str_XML &= "<" & Tabla & vbCrLf 'Inicializamos la etiqueta de la tabla
    '                '        End If
    '                '        For j = 0 To .lvwPesaje15.Columns.Count - 1
    '                '            campo = .lvwPesaje15.Columns.Item(j).Text
    '                '            If campo <> "Vehículo" And campo <> "Material" And campo <> "Kilos" Then
    '                '                valor = CStr(IIf(.lvwPesaje15.Items.Item(i).SubItems(j).Text Is DBNull.Value, "", .lvwPesaje15.Items.Item(i).SubItems(j).Text))
    '                '                '
    '                '                str_XML &= vbTab & campo & "=" & Chr(34) & valor & Chr(34) & vbCrLf
    '                '                '
    '                '            End If
    '                '        Next
    '                '        str_XML &= "/>"
    '                '    Next
    '                '    Return str_XML
    '        End Select
    '    End With
    'End Function
#End Region
#Region "Reporte Comandas"
    Public Function Obtener_CapturistaBascula(ByVal strConexion As String) As DataSet
        Dim ds As New DataSet
        Dim sError As String
        Try
            Cnn = New SqlConnection(strConexion)
            cmd = New SqlCommand("Select B.UsuarioId,B.Nombre_Completo from Entrada_Encabezado A Inner Join Usuarios B On (A.UsuarioId = B.UsuarioId) group by B.UsuarioId,B.Nombre_Completo", Cnn)
            cmd.CommandType = CommandType.Text       'asignar tipo de instruccion a ejecutar

            da = New SqlDataAdapter  'crear objeto data adapter
            da.SelectCommand = cmd     'ejecutar objeto command
            da.Fill(ds, "Capturista")       'llenar dataset
        Catch ex As SqlException
            sError = ex.Number & "-" & ex.Message
        Catch ex As Exception
            sError = ex.Source & "-" & ex.Message
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try
        Return ds
    End Function
#End Region

#Region "Alta rapida Proveedor"
    Public Function ValidaSinCamposVaciosARP(ByVal provee As FrmAltaRapidaProveedor, iTipoProveedorCliente As Integer) As Boolean
        ValidaSinCamposVaciosARP = True
        Dim faltantes As String = "Los Campos Faltantes son los siguientes:" & vbCrLf

        With provee
            If Trim(.txtNombres.Text) = "" And iTipoProveedorCliente = 1 Then
                ValidaSinCamposVaciosARP = False
                faltantes &= "-Nombres " & vbCrLf
            End If
            If Trim(.txtApellidos.Text) = "" And iTipoProveedorCliente = 1 Then
                ValidaSinCamposVaciosARP = False
                faltantes &= "-Apellidos " & vbCrLf
            End If
            '
            If Trim(.txtCalle.Text) = "" And iTipoProveedorCliente = 1 Then
                ValidaSinCamposVaciosARP = False
                faltantes &= "-Calle " & vbCrLf
            End If
            '
            If Trim(.txtCP.Text) = "" And iTipoProveedorCliente = 1 Then
                ValidaSinCamposVaciosARP = False
                faltantes &= "-Codigo Postal " & vbCrLf
            End If
            '
            If Trim(.txtRazonSocial.Text) = "" And iTipoProveedorCliente = 2 Then
                ValidaSinCamposVaciosARP = False
                faltantes &= "-Razon Social " & vbCrLf
            End If
            If Trim(.txtRepresentante.Text) = "" And iTipoProveedorCliente = 2 Then
                ValidaSinCamposVaciosARP = False
                faltantes &= "-Representante " & vbCrLf
            End If
            If Trim(.txtRFC.Text) = "" And iTipoProveedorCliente = 2 Then
                ValidaSinCamposVaciosARP = False
                faltantes &= "-R.F.C. " & vbCrLf
            End If
            If Trim(.txtCallePM.Text) = "" And iTipoProveedorCliente = 2 Then
                ValidaSinCamposVaciosARP = False
                faltantes &= "-Calle " & vbCrLf
            End If
            If Trim(.txtCP_PM.Text) = "" And iTipoProveedorCliente = 2 Then
                ValidaSinCamposVaciosARP = False
                faltantes &= "-Codigo Postal " & vbCrLf
            End If
            If Trim(.txtemail.Text) <> "" And validar_Mail(.txtemail.Text) = False And iTipoProveedorCliente = 1 Then
                faltantes &= "- Correo incorrecta" & vbCrLf
                ValidaSinCamposVaciosARP = False
            End If
            If Trim(.txtemailPM.Text) <> "" And validar_Mail(.txtemailPM.Text) = False And iTipoProveedorCliente = 2 Then
                faltantes &= "- Correo incorrecta" & vbCrLf
                ValidaSinCamposVaciosARP = False
            End If
        End With

        If ValidaSinCamposVaciosARP = False Then
            MsgBox(faltantes)
        End If
    End Function
    Public Sub Insertar_Actualizar_ProveedorARP(ByVal Clie As FrmAltaRapidaProveedor, iAccion As Integer, iTipoProveedorCliente As Integer)
        Dim Transaccion As SqlTransaction = Nothing
        Dim Client As Integer
        Dim iTipoPersona As Integer
        Dim iTipoPrecioId As Integer
        Try
            Cnn = New SqlConnection()
            Cnn.ConnectionString = cstrConnectBDapp
            Cnn.Open()


            With Clie
                Transaccion = Cnn.BeginTransaction
                cmd = Cnn.CreateCommand
                cmd.CommandText = "spABM_ProveedorCliente"
                '
                cmd.CommandType = CommandType.StoredProcedure
                If .txtFolioProveedorCliente.Text.Equals("") And iAccion = 1 Then
                    cmd.Parameters.Add(New SqlClient.SqlParameter("@ProveedorClienteId", 0))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("@accion", 1))
                Else
                    If Trim(.txtFolioProveedorCliente.Text) <> "" And iAccion = 2 Then
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@ProveedorClienteId", .txtFolioProveedorCliente.Text))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@accion", 2))
                    Else
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@ProveedorClienteId", .txtFolioProveedorCliente.Text))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@accion", 3))
                    End If
                End If
                'Tipo Persona
                iTipoPersona = CInt(IIf(.rbPersonaFisica.Checked = True, 1, 2))
                '
                cmd.Parameters.Add(New SqlClient.SqlParameter("@TipoProveedorClienteId", iTipoProveedorCliente))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Nombres", .txtNombres.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Apellidos", .txtApellidos.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@RazonSocial", .txtRazonSocial.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Representante", .txtRepresentante.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@PaisId", IIf(iTipoPersona = 1, .cboPais.SelectedValue, .cboPaisPM.SelectedValue)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@EstadoId", IIf(iTipoPersona = 1, .cboEstado.SelectedValue, .cboEstadoPM.SelectedValue)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@PoblacionId", IIf(iTipoPersona = 1, .cboMunicipio.SelectedValue, .cboPoblacionPM.SelectedValue)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@ColoniaId", IIf(iTipoPersona = 1, .cboColonia.SelectedValue, .cboColoniaPM.SelectedValue)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Calle", IIf(iTipoPersona = 1, .txtCalle.Text, .txtCallePM.Text)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@NumeroExterior", IIf(iTipoPersona = 1, .txtNumExterior.Text, .txtNumeroExteriorPM.Text)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@NumeroInterior", IIf(iTipoPersona = 1, .txtNuminterior.Text, .txtNumeroInteriorPM.Text)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@CP", IIf(iTipoPersona = 1, .txtCP.Text, .txtCP_PM.Text)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Telefono", IIf(iTipoPersona = 1, .txtTelefono.Text, .txtTelefonoPM.Text)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@email", IIf(iTipoPersona = 1, .txtemail.Text, .txtemailPM.Text)))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@UsuarioId", iUsuario))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@RFC", IIf(iTipoPersona = 1, Trim(.txtRFCPF.Text), Trim(.txtRFC.Text))))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@TipoPersonaId", iTipoPersona))
                '
                If .rbPrecioMayoreo.Checked Then
                    iTipoPrecioId = 1
                End If
                If .rbPrecioEspecial.Checked Then
                    iTipoPrecioId = 2
                End If
                If .rbPrecioSuperEspecial.Checked Then
                    iTipoPrecioId = 3
                End If
                cmd.Parameters.Add(New SqlClient.SqlParameter("@TipoPrecioId", iTipoPrecioId))
                '
                cmd.Transaction = Transaccion

                If .txtFolioProveedorCliente.Text.Equals("") And iAccion = 1 Then
                    Dim read As SqlDataReader = cmd.ExecuteReader()
                    read.Read()
                    Client = CInt(read(0))
                    MsgBox("Datos de Proveedor-Cliente registrados con exito")
                    read.Close()
                Else
                    If iAccion = 2 Then
                        cmd.ExecuteNonQuery()
                        MsgBox("Datos de Proveedor-Cliente dados de baja con exito")
                    Else
                        cmd.ExecuteNonQuery()
                        MsgBox("Datos de Proveeedor-Cliente actualizado con exito")
                    End If
                End If
            End With

            cmd.Dispose()
            Transaccion.Commit()
            If iAccion = 1 Then
                Clie.txtFolioProveedorCliente.Text = Format(Client, "000000")
            End If
            '
        Catch ex As Exception
            Transaccion.Rollback()
            MsgBox(ex.Message)
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try

    End Sub
#End Region
#Region "Procedimientos y Funciones de Sucursal"

    Public Function ABMSucursal(ByVal Sucursal As FrmSucursal, bBaja As Boolean) As Boolean
        ABMSucursal = False
        Dim Transaccion As SqlTransaction = Nothing
        Dim SucursalId As String = ""
        Try
            Cnn = New SqlConnection()
            Cnn.ConnectionString = cstrConnectBDapp
            Cnn.Open()

            With Sucursal
                Transaccion = Cnn.BeginTransaction
                cmd = Cnn.CreateCommand
                cmd.CommandText = "spABMSucursales"
                '
                cmd.CommandType = CommandType.StoredProcedure
                '
                If bBaja = False Then
                    If .TxtSucursalId.Text.Equals("") Then
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@Accion", 1))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@SucursalId", 0))
                    Else
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@Accion", 2))
                        cmd.Parameters.Add(New SqlClient.SqlParameter("@SucursalId", .TxtSucursalId.Text))
                    End If
                Else
                    cmd.Parameters.Add(New SqlClient.SqlParameter("@Accion", 3))
                    cmd.Parameters.Add(New SqlClient.SqlParameter("@SucursalId", .TxtSucursalId.Text))
                End If

                cmd.Parameters.Add(New SqlClient.SqlParameter("@Descripcion", .txtRazonSocial.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Calle", .txtCalle.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@NumeroExterior", .txtNumExterior.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@NumeroInterior", .txtNuminterior.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@CP", .txtCP.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@ColoniaId", .cboColonia.SelectedValue))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@PoblacionId", .cboMunicipio.SelectedValue))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@EstadoId", .cboEstado.SelectedValue))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@PaisId", .cboPais.SelectedValue))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Fax", .txtFax.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Email", .txtemail.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Telefono", .txtTelefono.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@EmpresaId", 1))
                '
                cmd.Transaction = Transaccion
                If bBaja = False Then
                    If .TxtSucursalId.Text.Equals("") Then
                        Dim read As SqlDataReader = cmd.ExecuteReader()
                        read.Read()
                        SucursalId = CStr(read(0))
                        MsgBox("Datos de Sucursal registrados con exito")
                        read.Close()
                    Else
                        cmd.ExecuteNonQuery()
                        MsgBox("Datos de Sucursal actualizado con exito")
                    End If
                Else
                    cmd.ExecuteNonQuery()
                    MsgBox("La Sucursal se dio de baja con exito")
                End If
            End With

            cmd.Dispose()
            Transaccion.Commit()
            Sucursal.TxtSucursalId.Text = SucursalId
            ABMSucursal = True
        Catch ex As SqlException
            Transaccion.Rollback()
            MsgBox(ex.Number & "-" & ex.Message, MsgBoxStyle.Critical)
        Catch ex As Exception
            Transaccion.Rollback()
            MsgBox(ex.Message)
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try

    End Function

    Public Function Busqueda_Sucursales(ByVal listado As ListView) As Boolean
        Busqueda_Sucursales = True
        Dim cadena(2) As String
        Try

            Cnn = New SqlConnection()
            Cnn.ConnectionString = cstrConnectBDapp
            Cnn.Open()
            '
            cmd = Cnn.CreateCommand
            cmd.CommandText = "spBusqueda_Sucursales"
            cmd.CommandType = CommandType.StoredProcedure
            'cmd.Parameters.Add(New SqlClient.SqlParameter("@accion", 1))

            Dim read As SqlDataReader = cmd.ExecuteReader()
            listado.Items.Clear()
            If read.HasRows Then
                While read.Read

                    Dim item1 As ListViewItem
                    cadena(0) = CStr(read(0))
                    cadena(1) = CStr(read(1))
                    item1 = New ListViewItem(cadena)

                    listado.Items.Add(item1)
                End While
            Else
                MsgBox("No se han encontrado sucursales")

            End If
        Catch ex As Exception
            MsgBox(ex.Message)

        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try
    End Function
    Public Sub CargaDatosSucursal(ByVal Sucursal As FrmSucursal, iSucursalId As Integer)
        Try
            Cnn = New SqlConnection()
            Cnn.ConnectionString = cstrConnectBDapp
            Cnn.Open()
            '
            cmd = Cnn.CreateCommand
            cmd.CommandText = "spCargaDatosSucursal"
            cmd.CommandType = CommandType.StoredProcedure
            '
            cmd.Parameters.Add(New SqlClient.SqlParameter("@SucursalId", iSucursalId))
            '
            With Sucursal
                '
                Dim read As SqlDataReader = cmd.ExecuteReader()
                If read.HasRows Then
                    While read.Read
                        .TxtSucursalId.Text = CStr(read(0))
                        .txtRazonSocial.Text = CStr(read(1))
                        .txtCalle.Text = CStr(read(2))
                        .txtNumExterior.Text = CStr(read(3))
                        .txtNuminterior.Text = CStr(read(4))
                        .txtCP.Text = CStr(read(5))
                        .cboEstado.SelectedValue = CInt(read(8))
                        .cboMunicipio.SelectedValue = CInt(read(7))
                        .cboColonia.SelectedValue = CInt(read(6))
                        .txtFax.Text = CStr(read(10))
                        .txtemail.Text = CStr(read(11))
                        .txtTelefono.Text = CStr(read(12))
                    End While
                End If
            End With
            '
            cmd.Dispose()
            '
        Catch ex As Exception
            MsgBox(ex.Message)
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try

    End Sub
#End Region

#Region "Procedimientos y Funciones de Ventanilla-NotaVenta"
    Public Sub Insertar_NotaVenta(ByVal CajaPago As FrmCajaPago)
        Dim Transaccion As SqlTransaction = Nothing
        'Dim TempNotaId As Integer
        Try
            iNotaId = 0
            Cnn = New SqlConnection()
            Cnn.ConnectionString = cstrConnectBDapp
            Cnn.Open()
            '
            With CajaPago
                Transaccion = Cnn.BeginTransaction
                cmd = Cnn.CreateCommand
                cmd.CommandText = "spIngresaCobro"
                '
                cmd.CommandType = CommandType.StoredProcedure
                cmd.Parameters.Add(New SqlClient.SqlParameter("@UsuarioId", iUsuario))
                '
                cmd.Parameters.Add(New SqlClient.SqlParameter("@NotaFecha", Now))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@NotaTotal", .txtNeto.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@ClienteId", 1))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@NotaCambio", .txtCambio.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@NotaPago", .txtEfectivo.Text))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@XML_Nota_Detalle", XMLNotaVentaDetalle))
                cmd.Parameters.Add(New SqlClient.SqlParameter("@Descuento", .txtDescuento.Text))
                '
                cmd.Transaction = Transaccion


                Dim read As SqlDataReader = cmd.ExecuteReader()
                read.Read()
                iNotaId = CInt(read(0))
                MsgBox("Datos de Nota registrados con exito")
                read.Close()
            End With
            '
            cmd.Dispose()
            Transaccion.Commit()
            'If iAccion = 1 Then
            '    Prod.iProductoId = TempProdId
            'End If
            '
        Catch ex As Exception
            Transaccion.Rollback()
            MsgBox(ex.Message)
        Finally
            If Not Cnn Is Nothing Then
                If Cnn.State = ConnectionState.Open Then
                    Cnn.Close()    'cerrar conexion
                    Cnn = Nothing     'destruir objeto
                End If
            End If
        End Try

    End Sub
#End Region

    Public Function Numero(ByVal e As System.Windows.Forms.KeyPressEventArgs, ByRef cajasTexto As TextBox) As Boolean
        If UCase(e.KeyChar) Like "[!0-9.-]" Then
            Return True
        End If

        Dim c As Short = 0
        If UCase(e.KeyChar) Like "[.]" Then
            If InStr(cajasTexto.Text, ".") > 0 Then
                Return True
            Else
                Return False
            End If
        End If
    End Function
End Module
