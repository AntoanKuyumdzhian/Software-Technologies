function solve(args) {
    let i = 0;
    let stop = "Stop";
    while (args[i] != stop) {
        console.log(args[i]);
        i++;
    }
}

solve(['Line 1','Line 2','Line 3','Stop']);