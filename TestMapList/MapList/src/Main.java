import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;
import java.util.stream.Collectors;

public class Main {
    public static void main(String[] args) {
        List<Integer> numbers = new ArrayList<>(Arrays.asList(1,2,3,4,5,6));

        System.out.println(Arrays.toString(numbers.toArray()));

        numbers.stream().map(String::valueOf).collect(Collectors.toList());
        System.out.println(Arrays.toString(numbers.toArray()));


    }
}