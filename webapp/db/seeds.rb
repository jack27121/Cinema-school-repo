#User.create(email: 'user@example.com', name: 'username', password: 'password' );

2.times do
  Movie.create({
    title: 'No Time To Die',
    description: 'James Bond does a backflip',
    age_rating: 12,
    image_path: 'https://cdn.shopify.com/s/files/1/0057/3728/3618/products/no-time-to-die_krgsl7mv_480x.progressive.jpg?v=1604419849',
    trailer_path: 'https://www.youtube.com/watch?v=vw2FOYjCz38',
    release: '2021-10-01'
  })
end
