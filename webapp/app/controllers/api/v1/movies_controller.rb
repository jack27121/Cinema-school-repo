module Api
  module V1
    class MoviesController < ApplicationController
      # GET api/v1/movies
      def index
        movies = Movie.all
        render json: movies
      end

      # GET api/v1/movies/:id
      def show
        movie = Movie.find(params[:id])
        render json: movie
      end

      # POST api/v1/movies
      def create
        movie = Movie.new(movie_params) #calls the movie_params function, which validates the passed params
        if movie.save #this if statement runs movie.save and renders json if it succeeds, or an error if not
          render json: movie
        else
          render json: {status: 'ERROR', message:'movie not saved', data: movie.errors}
          #status: :unprocessable_entity
        end
      end

      # DELETE api/v1/movies/:id
      def destroy
        movie = Movie.find(params[:id])
        movie.destroy

        render json: Movie.all
      end

      private

      def movie_params
        params.permit(:title,:description,:age_rating,:image_path,:trailer_path,:release)
      end

    end
  end
end