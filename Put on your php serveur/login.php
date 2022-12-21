<?php 
	//Le nom de ta base 
	$dbName = '';
	//Le lien de ta base 
    $host = '';
	//usersname pour se co a la base 
    $username = '';
	//mdp pour se connecter a la base 
    $password = '';
    $bdd = new PDO('mysql:host='.$host.';dbname='.$dbName.';charset=utf8', $username,$password,array(PDO::MYSQL_ATTR_INIT_COMMAND => "SET NAMES utf8"));
	//pseudo pour se co
	$users=$_GET["usersname"];
	//mdp pour se connecter , md5 = crypté mais attention ne pas utliser ce cryptage en production car c'est devenu obselete
	$pass=md5($_GET["pass"]);
    $req = "Select * from  `users_hein` where usersname='$users' and password='$pass'";
    $res = $bdd->query($req);
    $laLigne = $res->fetchall();
	echo json_encode($laLigne);
?>