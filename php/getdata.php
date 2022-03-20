<?php
$servername = "localhost";//for 000webhost leave it as it is.
$username = "username to login to database";
$password = "password to login to database";
$dbname = "database name";
//login vars
$loginUser = $_POST["loginUser"];
$loginPass = $_POST["loginPass"];
// Create connection
$conn = new mysqli($servername, $username, $password, $dbname); //connects to database
// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT money, password FROM users WHERE username = '" .$loginUser ."'";//fetchs money and password from database
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    //check the password
    if ($row["password"] == $loginPass){
        echo $row["money"];
    }
    else{
        echo "Invalid Credentials";
    }
    
    }
    }
  
 else {
  echo "Invalid Credentials";
}
$conn->close();
?>