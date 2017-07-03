<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <title>First Steps Into PHP</title>

</head>
<body>
    <form>
        N: <input type="text" name="num" />
        <input type="submit" />
    </form>

    <?php
    if (isset($_GET['num'])){
        $num = intval($_GET['num']);
        $Fibo1 = 1;
        $Fibo2 = 0;
        $Fibo3 = 0;
        $fibNumber = 0;

        for ($i = 0; $i < $num; $i++){
            $fibNumber = $Fibo1 + $Fibo2 + $Fibo3;
            $Fibo1 = $Fibo2;
            $Fibo2 = $Fibo3;
            $Fibo3 = $fibNumber;
            echo $fibNumber . " ";
        }
    }
    ?>
</body>
</html>