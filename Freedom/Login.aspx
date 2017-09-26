<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="Login.aspx.vb" Inherits="Freedom.Login" %>

<!DOCTYPE html>
<html>
<head>
    <meta http-equiv="content-type" content="text/html;charset=UTF-8" />
    <meta charset="utf-8" />
    <title>CodeBuilders - Iniciar Sesion</title>
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=no, shrink-to-fit=no" />
    <link rel="apple-touch-icon" href="../pages/ico/60.png">
    <link rel="apple-touch-icon" sizes="76x76" href="../pages/ico/76.png">
    <link rel="apple-touch-icon" sizes="120x120" href="../pages/ico/120.png">
    <link rel="apple-touch-icon" sizes="152x152" href="../pages/ico/152.png">
    <link rel="icon" type="image/x-icon" href="favicon.ico" />
    <meta name="apple-mobile-web-app-capable" content="yes">
    <meta name="apple-touch-fullscreen" content="yes">
    <meta name="apple-mobile-web-app-status-bar-style" content="default">
    <meta content="" name="description" />
    <meta content="" name="author" />
    <link href="Assets/plugins/pace/pace-theme-flash.css" rel="stylesheet" type="text/css" />
    <link href="Assets/plugins/bootstrapv3/css/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <link href="Assets/plugins/font-awesome/css/font-awesome.css" rel="stylesheet" type="text/css" />
    <link href="Assets/plugins/jquery-scrollbar/jquery.scrollbar.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="Assets/plugins/select2/css/select2.min.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="Assets/plugins/switchery/css/switchery.min.css" rel="stylesheet" type="text/css" media="screen" />
    <link href="Pages/css/pages-icons.css" rel="stylesheet" type="text/css">
    <link class="main-stylesheet" href="Pages/css/pages.css" rel="stylesheet" type="text/css" />
    <!--[if lte IE 9]>
        <link href="pages/css/ie9.css" rel="stylesheet" type="text/css" />
    <![endif]-->
    <script type="text/javascript">
        window.onload = function () {
            // fix for windows 8
            if (navigator.appVersion.indexOf("Windows NT 6.2") != -1)
                document.head.innerHTML += '<link rel="stylesheet" type="text/css" href="../Pages/css/windows.chrome.fix.css" />'
        }
    </script>
</head>
<body class="fixed-header ">
    <div class="login-wrapper ">
        <div class="bg-pic">
            <img src="Assets/img/demo/new-york-city-buildings-sunrise-morning-hd-wallpaper.jpg" data-src="../Assets/img/demo/new-york-city-buildings-sunrise-morning-hd-wallpaper.jpg" data-src-retina="../Assets/img/demo/new-york-city-buildings-sunrise-morning-hd-wallpaper.jpg" alt="" class="lazy">
            <div class="bg-caption pull-bottom sm-pull-bottom text-white p-l-20 m-b-20">
                <h2 class="semi-bold text-white">Pages make it easy to enjoy what matters the most in the life</h2>
                <p class="small">
                    images Displayed are solely for representation purposes only, All work copyright of respective owner, otherwise © 2013-2014 REVOX.
                </p>
            </div>
        </div>

        
        <div class="login-container bg-white">
            <div class="p-l-50 m-l-20 p-r-50 m-r-20 p-t-50 m-t-30 sm-p-l-15 sm-p-r-15 sm-p-t-40">
                <div class="card card-transparent" style="width:375px !important; height:390px !important;">
	                <ul class="nav nav-tabs nav-tabs-fillup" data-init-reponsive-tabs="dropdownfx">
		                <li class="nav-item" style="width:50% !important">
			                <a href="#" class="active" data-toggle="tab" data-target="#slide1"><span style="text-align:center">Ingresar</span></a>
		                </li>
		                <li class="nav-item" style="width:50% !important">
			                <a href="#" data-toggle="tab" data-target="#slide2"><span style="text-align:center">Registrarse</span></a>
		                </li>
	                </ul>
                    <form runat="server" class="p-t-15" role="form" novalidate>
	                    <div class="tab-content">
		                    <div class="tab-pane slide-left active" id="slide1">
                                <%--<img src="../assets/img/logo.png" alt="logo" data-src="../assets/img/logo.png" data-src-retina="../assets/img/logo_2x.png" width="78" height="22">--%>
                                <p class="p-t-35">Iniciar Sesión</p>
                                    <div class="form-group-attached">
	                                    <div class="form-group form-group-default required">
		                                    <label>Login</label>
                                            <div class="controls">
                                                 <asp:TextBox ID="txtUsername" runat="server" class="form-control"
                                                        MaxLength="255" name="usuario" placeholder="Usuario" runat="server" ClientIDMode="Static">
                                                </asp:TextBox>
                                            </div>
	                                    </div>
                                        <div class="form-group form-group-default">
                                            <label>Password</label>
                                            <div class="controls">
                                                <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" class="form-control"
                                                        name="contraseña" placeholder="Contraseña" ClientIDMode="Static">
                                                 </asp:TextBox>
                                            </div>
                                        </div><br />
                                        <div class="row">
                                            <div class="col-md-6 no-padding">
                                                <div class="checkbox ">
                                                    <input type="checkbox" ID="chkboxPersist" data-id="chkboxPersist" runat="server"/>
                                                    <label for="chkboxPersist">Recordarme?</label>
                                                </div>
                                            </div>
                                            <div class="col-md-6 text-right">
                                                <button class="btn btn-primary btn-cons m-t-10 pull-right" id="btnLogin" type="button">
							                        <span>Ingresar</span>
						                        </button>
                                            </div>
                                        </div>
                                    </div>
		                    </div>
		                    <div class="tab-pane slide-left" id="slide2">
                                    <div class="form-group-attached">
	                                    <div class="form-group form-group-default required">
		                                    <label>Nombre</label>
                                            <input type="text" runat="server" id="txtNombre" name="uname" placeholder="Nombre Completo" class="form-control" required>
	                                    </div>
	                                    <div class="row clearfix">
		                                    <div class="col-md-6">
			                                    <div class="form-group form-group-default required">
				                                    <label>Apellido Paterno</label>
                                                    <input type="text" runat="server" id="txtApellidoPaterno" name="surnameP" placeholder="Paterno" class="form-control" required>
			                                    </div>
		                                    </div>
		                                    <div class="col-md-6">
			                                    <div class="form-group form-group-default">
				                                    <label>Apellido Materno</label>
                                                    <input type="text" runat="server" id="txtApellidoMaterno" name="surnameM" placeholder="Materno" class="form-control" required>
			                                    </div>
		                                    </div>
	                                    </div>
                                        <div class="row clearfix">
		                                    <div class="col-md-6">
			                                    <div class="form-group form-group-default required">
				                                    <label>Email</label>
                                                    <input type="email" runat="server" id="txtEmail" name="email" placeholder="Correo electronico" class="form-control" required>
                                                </div>
		                                    </div>
		                                    <div class="col-md-6">
			                                    <div class="form-group form-group-default">
				                                    <label>Teléfono</label>
                                                    <input type="text" runat="server" id="txtTelefono" name="phone" maxlength="10" placeholder="Celular" class="form-control" required>
                                                </div>
		                                    </div>
	                                    </div>
                                        <div class="row clearfix">
		                                    <div class="col-md-6">
			                                    <div class="form-group form-group-default required">
				                                    <label>Contraseña</label>
                                                    <input type="password" runat="server" id="txtPass" name="pass" placeholder="Mínimo de 6 carácteres" class="form-control" required>
                                                </div>
		                                    </div>
		                                    <div class="col-md-6">
			                                    <div class="form-group form-group-default">
				                                    <label>Confirmar Contraseña</label>
                                                    <input type="password" runat="server" id="txtConfirmarPass" name="pass2" placeholder="Repetir contraseña" class="form-control" required>
                                               </div>
		                                    </div>
	                                    </div>
                                        <div class="row pull-right">
                                            <div class="col-md-12">
                                                <button class="btn btn-primary btn-cons m-t-10" id="btnRegistrarse" type="button">
							                        <span>Registrarse</span>
						                        </button>
                                            </div>
                                        </div>
                                    </div>
		                        </div>
	                        </div>
                        </form>
                    </div>
                </div>
            </div>
    </div>
    <!-- BEGIN VENDOR JS -->

    <div class="modal fade slide-up disable-scroll" id="modalSmall" tabindex="-1" role="dialog" aria-hidden="false">
	    <div class="modal-dialog modal-sm">
		    <div class="modal-content-wrapper">
			    <div class="modal-content">
				    <div class="modal-body text-center m-t-20">
					    <h4 class="no-margin p-b-10" id="msgModalSmall">...</h4>
					    <button type="button" class="btn btn-primary btn-cons" data-dismiss="modal">Continuar</button>
				    </div>
			    </div>
		    </div>
	    </div>
    </div>

    <script src='<%= ResolveUrl("~/Assets/plugins/pace/pace.min.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Assets/plugins/jquery/jquery-2.1.1.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Assets/plugins/modernizr.custom.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Assets/plugins/jquery-ui/jquery-ui.min.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Assets/plugins/bootstrapv3/js/bootstrap.min.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Assets/plugins/jquery/jquery-easy.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Assets/plugins/jquery-unveil/jquery.unveil.min.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Assets/plugins/jquery-bez/jquery.bez.min.js")%>'></script>
    <script src='<%= ResolveUrl("~/Assets/plugins/jquery-ios-list/jquery.ioslist.min.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Assets/plugins/jquery-actual/jquery.actual.min.js")%>'></script>
    <script src='<%= ResolveUrl("~/Assets/plugins/jquery-scrollbar/jquery.scrollbar.min.js")%>'></script>
    <script type="text/javascript" src='<%= ResolveUrl("~/Assets/plugins/select2/js/select2.full.min.js")%>'></script>
    <script type="text/javascript" src='<%= ResolveUrl("~/Assets/plugins/classie/classie.js")%>'></script>
    <script src='<%= ResolveUrl("~/Assets/plugins/switchery/js/switchery.min.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Assets/plugins/rickshaw/vendor/d3.min.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Assets/plugins/rickshaw/vendor/d3.layout.min.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Assets/plugins/rickshaw/rickshaw.min.js")%>' type="text/javascript"></script>
    <script src='<%= ResolveUrl("~/Pages/js/pages.min.js")%>'></script>
    <script src='<%= ResolveUrl("~/Assets/js/scripts.js") %>' type="text/javascript"></script>
    <script src='<%= Freedom.VersionFile.Check(ResolveUrl("~/App/js/Base.js")) %>' type="text/javascript"></script>
    <script src='<%= Freedom.VersionFile.Check(ResolveUrl("~/App/js/Usuario.js")) %>' type="text/javascript"></script>

</body>
</html>
