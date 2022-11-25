#include<iostream>
#include "functions.h"
#include "functions.cpp"



int main() {



	bool ai_first = true;
	bool game_is_finished = false;
	draw_board(board);


	while (game_is_finished == false) {
		player_1_move();
		draw_board(board);
		winner = check_if_game_is_finished(board);
			if (winner == 'x'){ 
				std::cout<<"GAME OVER\n The Winner is X\n";
				break; 
			}
			else if (winner == 'o'){
				std::cout<<"GAME OVER\n The Winner is O\n";
				break; 
			}
			else if (winner == 't'){
				std::cout<<"GAME OVER\n Tied";
				break;
			}

		player_2_move();
		draw_board(board);
		winner = check_if_game_is_finished(board);
			if (winner == 'x'){ 
				std::cout<<"GAME OVER\n The Winner is X\n";
				break; 
			}
			else if (winner == 'o'){
				std::cout<<"GAME OVER\n The Winner is O\n";
				break; 
			}
			else if (winner == 't'){
				std::cout<<"GAME OVER\n Tied";
				break;
			}
	}


	return 0;
}
