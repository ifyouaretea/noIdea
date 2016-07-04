<?<?php 
	$servername = 'capstoneskyeye.cfyrhe0diz6p.us-west-2.rds.amazonaws.com';
	$serverusername = 'calvinlee708';
	$serverpassword = 'chwb5278';
	$dbName = 'games';
	// $username = $_REQUEST['username'];
	// $userpassword = $_REQUEST['userpassword'];
	$username = $_POST['username'];
	$userpassword = $_POST['userpassword'];


	//Make connection with the 4 variables
	$conn = new mysqli($servername, $serverusername, $serverpassword, $dbName);

	//Check connection
	if(!$conn){
		die("Connection Failed. ". mysqli.connect_error());
	}
	$sql = "SELECT COUNT(id) FROM games WHERE id = '$username' AND pw = '$userpassword' LIMIT 0, 1";
	$result = mysqli_query($conn, $sql);
	$row = mysqli_fetch_array($result);
	if($row[0]==1){
		echo "True";
	}else{
		echo "False";
	}
 ?>