<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
    <style>
        div {
            display: inline-block;
            margin: 5px;
            width: 20px;
            height: 20px;
        }
    </style>
</head>
<body>
<?php
for ($row = 0; $row <= 204; $row+=51){
    for ($col = 0; $col <= 45; $col+=5){
        $color = $row + $col;
        echo "<div style=\"background-color: rgb($color, $color, $color);\">";
        echo "</div>";
    }
    echo "<br>";
}
?>

</body>
</html>