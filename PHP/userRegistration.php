<?<?php 
	$servername = 'capstoneskyeye.cfyrhe0diz6p.us-west-2.rds.amazonaws.com';
	$serverusername = 'calvinlee708';
	$serverpassword = 'chwb5278';
	$dbName = 'games';
	// $username = $_POST['username'];
	// $userpassword = $_POST['userpassword'];
	$username = $_REQUEST['username'];
	$userpassword = $_REQUEST['userpassword'];


	//Make connection with the 4 variables
	$conn = new mysqli($servername, $serverusername, $serverpassword, $dbName);

	//Check connection
	if(!$conn){
		die("Connection Failed. ". mysqli.connect_error());
	}
	$sql = "INSERT INTO games.games (usernumber, id, pw, timestamp) VALUES (default,'$username','$userpassword', NOW())";
	$result = mysqli_query($conn, $sql);
	echo $result;
	// echo "Everything ok".mysqli_error($conn);
	if(!mysqli_error($conn)){
		echo "Registration Successful";
	}else{
		echo "Duplicate username";
	}

	$conn->close();
?>