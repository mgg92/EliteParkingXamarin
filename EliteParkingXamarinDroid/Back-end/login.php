<?php

			function test_input($data) {
			  $data = trim($data);
			  $data = stripslashes($data);
			  $data = htmlspecialchars($data);
			  return $data;
			}

			$user = $pw = "";

			if ($_SERVER["REQUEST_METHOD"] == "GET") {

			 	$user = test_input($_GET["cedula"]);
			  	$pw = test_input($_GET["contrasena"]);

				$servername = "localhost";
				$username = "u511611292_root";
				$password = "t00rep";
				$dbname = "u511611292_ep";

				try {
				    $conn = new PDO("mysql:host=$servername;dbname=$dbname", $username, $password);
				    // set the PDO error mode to exception
				    $conn->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
				    //echo "Connected successfully"; 
				    $stmt = $conn->prepare("SELECT UsuarioAppNombre,UsuarioAppPrimerApellido,ultimoAcceso FROM `UsuarioApp` WHERE `UsuarioAppCedula` = $user AND `UsuarioAppContrasena` = '" . $pw . "'"); 
		    		$stmt->execute();

					header('Content-type: application/json; charset=utf-8');					
					$arr = $stmt->fetch(PDO::FETCH_ASSOC);
					
					echo json_encode($arr);
					/*$date = date('Y-m-d H:i:s', time());
					echo $date;*/
				}
				catch(PDOException $e) {
					echo "Error al conectar a la base de datos <br>" . $e->getMessage();
				}
				$conn = null;
			}			
?>