namespace Lab2



module Calculator =



  open Tree



  // This part of the assignment requires Tree from Tree.fs to be polymorphic.
  // If you have not yet made Tree polymorphic, do so. If you do not understand
  // what "making Tree polymorphic" means, consult a learning resource. A good
  // place to start is the course home page, specifically the slides from
  // the lecture about polymorphism, recursive data types and trees.
  //
  // Your task is now to build an evaluator for floating-point arithmetic
  // expressions. Just like in BST.fs, you cannot declare a new tree type.
  // Instead you have to use the interface you defined in Tree.fs. However,
  // you will have to define a type for floating-point operators and operands,
  // called Expr. By combining Expr and the interface from Tree.fs you will be
  // able to construct floating-point arithmetic expressions.
  //
  // There are no FsCheck tests written for this module. Instead, we recommend
  // that you define some arithmetic expressions using the expr function (you
  // will define it later), to test your code with. This will help you in the
  // development process as well as make it easier for the teaching assistants
  // to judge your solution.



  // Declare Expr, a type for arithmetic operators and operands.
  //
  // Expr supports the following operators:
  //   * addition
  //   * subtraction
  //   * multiplication
  //   * division
  //
  // Expr supports the following operands:
  //   * constans of type float



  // type Expr....



  // val expr : Tree<Expr> -> Expr -> Tree<Expr> -> Tree<Expr>
  // Given a tree t1, an operator o, and a tree t2, it returns a tree t3.
  // t3 is a root node with t1 as the left child, t2 as the right child
  // and o as the element.



  // let expr...



  // val eval : Tree<Expr> -> float
  // Given a float-point arithmetic expression e, it evaluates e and returns
  // the resulting floating-point value.



  // let eval...
