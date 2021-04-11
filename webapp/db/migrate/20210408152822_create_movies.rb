class CreateMovies < ActiveRecord::Migration[5.1]
  def change
    create_table :movies do |t|
      t.string :title
      t.text :description
      t.integer :age_rating
      t.text :image_path
      t.text :trailer_path
      t.date :release

      t.timestamps
    end
  end
end
