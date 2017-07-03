<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>
</head>
<body>

<?php
for ($i = 1; $i <= 9; $i++){
    for ($j = 1; $j <= 5; $j++){
        $num = 0;
        if ($i == 1 || $i == 5 || $i == 9){
            $num = 1;
        }
        else if ($i > 1 && $i < 5 && $j == 1){
            $num = 1;
        }
        else if ($i > 5 && $i < 9 && $j == 5){
            $num = 1;
        }
        if ($num == 1){
            echo "<button style='background-color: blue'>1</button>";
        }
        else{
            echo "<button>0</button>";
        }

    }
    echo "<br>";
}
?>
</body>
</html>