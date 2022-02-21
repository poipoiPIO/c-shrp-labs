exception Empty_list of string;;
exception Unmatched_elem of string;;

(* type linked has two elems empty list "Nil" and List which is 
   tuple of two elems list of generic type and value of generic type *)
type 'a linked = Nil | List of 'a * 'a linked 

let car linked = 
  (* lisp-like car function give us a head of a list *)
  match linked with
  | Nil -> raise (Empty_list "List is Nil!")
  | List(head, _) -> head
;;

let cdr linked =
  (* lisp-like cdr function give us a rest of a list *)
  match linked with
  | Nil -> raise (Empty_list "List is Nil!")
  | List(_, rest) -> rest
;;

let cons (value: 'a) linked = 
  (* lisp-like consolidation function give us a list 
     with head of elem and rest of original list*)
  match linked with 
  | Nil -> List(value, Nil)
  | List(top, _) -> List(value, linked)
;;

let rec append xs list' =
  (* add element to the end of list *)
  match list' with 
  | Nil -> List(xs, Nil)
  | _   -> cons (car list') (append xs (cdr list'))
;;

let rec find_node_or_die value linked = 
  (* return the first node of finding elem 
     or raised exception if cant find it*)
  match linked with 
  | Nil -> raise (Unmatched_elem "Can't find elem")
  | List(car, _) when car = value ->  linked
  | _ -> find_node_or_die  value (cdr linked)
;;

let string_of_linked str_conv linked =
  (*  ocaml doesn't have a universal printer function so,
      we need to implement it ourselves *)
  let rec string_of_linked' linked' acc =
    match linked' with 
    | List(value, Nil) -> acc ^ (str_conv value) ^ "]"
    | List(value, next_node) -> 
        string_of_linked' next_node (acc ^ (str_conv value) ^ " ")
    | _ -> "Empty"
  in string_of_linked' linked "["
;;

let link = List(12, List(13, List(14, Nil)));;
print_string "For now we have linked list like that: ";;
print_endline (string_of_linked string_of_int link);;
print_endline ("Let's consolidate it with num 11:      " ^ 
  (string_of_linked string_of_int (cons 11 link)));;
print_endline ("Let's append it with num 15:           " ^ 
  (string_of_linked string_of_int (append 15 link)));;
print_endline ("Let's find the node that has value 12: " ^ 
  (string_of_linked string_of_int (find_node_or_die 12 link)));;
