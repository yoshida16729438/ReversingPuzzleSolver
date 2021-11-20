# ReversingPuzzleSolver
Solver program of "reversing puzzle" . ( Sorry I don't know how it is called in English ... )
<br><br>
Japanese：<br>
正方形のタイルを3×3や4×4の大きな四角形に並べた盤面上で、いくつかのタイルをクリックしその色を変更することで、盤面全体を一色にするようなパズルのソルバープログラムです。（Exampleの項も参照）<br>
日本語では「ライツアウト」と呼ばれているパズルだそうです。<br>
一般的にはタイルは表と裏の二面であり、タイルをクリックするたびにクリックされたタイルとその周りの上下左右のタイルの計5枚の裏表が反転する、というものですが、派生形として、クリックするたびに色が3色以上でループするものや、上下左右だけでなく斜め上や斜め下のタイルも含めて9枚の裏表が反転するものもあるようです。<br>
それらの派生形にも対応出来たら、と思っていますが、実装できるかはわかりません……<br>
<br>
<br>
English：<br>
There is a type of puzzle like below (please refer to "Example", too):<br>
・consists of square tiles of 3 by 3, 4 by 4 or more bigger<br>
・when you clicked one of the tiles, the clicked tile and 4 tiles around it (upper, lower, right, left) turn front to back<br>
・your purpose is to make the tiles same color<br>
This program is (or will be) solver program of this type of puzzle.<br>
This type of puzzle is called as "lights out" in Japanese.<br>
Standard version of the puzzle has just 2 colors, but there are some varieties : 3 or more colors, not only 4 tiles around clicked one, but also more 4 tiles (diagonally above/below left/right). etc..<br>
I wanna try to make this program can handle those varieties, but I wonder if I can ....<br>
<br>
Example：<br>
（表が白、裏が黒のイメージで、中心のタイルをクリックしたものと考えてください）<br>
（think as front = white, back = black, and you clicked the center tile）<br>
□□□<br>
□□□<br>
□□□<br>
↓<br>
 □■□<br>
■■■<br>
 □■□<br>
