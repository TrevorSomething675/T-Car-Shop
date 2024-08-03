using T_Car_Shop.Application.Repositories;
using T_Car_Shop.DataAccess.Repositories;
using T_Car_Shop.Infrastructure.Services;
using T_Car_Shop.Core.Models.DataAccess;
using T_Car_Shop.Application.Services;
using T_Car_Shop.DataAccess.Contexts;
using T_Car_Shop.Infrastructure;
using T_Car_Shop.Web.Extensions;
using T_Car_Shop.Core.Enums;
using Minio.DataModel.Args;
using System.Reflection;
using Minio;
using Microsoft.EntityFrameworkCore;

namespace T_Car_Shop.Web
{
	public class Startup
	{
		public async void ConfigureServices(IServiceCollection services)
		{
			services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetAssembly(typeof(AssemblyMarker))));
			services.AddSwaggerGen();
			services.AddAppOptions();
			services.AddControllers();

			services.AddAppAuth();
			services.AddAppMinio();
			services.AddAppDbContext();
			services.AddAppAutoMapper();

			services.AddScoped<ICarRepository, CarRepository>();
			services.AddScoped<IUserRepository, UserRepository>();
			services.AddScoped<IRoleRepository, RoleRepository>();
			services.AddScoped<IManufacturerRepository, ManufacturerRepository>();
			services.AddScoped<INotificationRepository, NotificationRepository>();
			services.AddScoped<IPersonalNotificationRepository, PersonalNotificationRepository>();

			services.AddScoped<ITokenService, TokenService>();
			services.AddScoped<IMinioService, MinioService>();
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<ICarService, CarService>();
			services.AddScoped<IManufacturerService, ManufacturerService>();
			services.AddScoped<INotificationService, NotificationService>();
			services.AddScoped<IPersonalNotificationService,  PersonalNotificationService>();
			
            using (var context = services.BuildServiceProvider().GetRequiredService<MainContext>())
            {
                context.Database.EnsureDeleted();
				context.Database.Migrate();
                context.Database.EnsureCreated();

				if (!context.Roles.Any()) 
				{
					context.AddRange(new List<RoleEntity>
					{
						new RoleEntity
						{
							Name = "User"
						},
						new RoleEntity
						{
							Name = "Manager"
						},
						new RoleEntity
						{
							Name = "Admin"
						}
					});
					await context.SaveChangesAsync();
				}

				context.Users.AddRange(new List<UserEntity>
				{
					new UserEntity
					{
						Name = "UserName999",
						Password = "123123123",
						Role = context.Roles.FirstOrDefault(r => r.Name == "User"),
						UserNotification = new List<UserNotificationEntity>
						{
							new UserNotificationEntity
							{
								Notification = new NotificationEntity
								{
									Header = "Notification1Header",
									Content = "Notification1ContentNotification1ContentNotification1ContentNotification1ContentNotification1ContentNotification1ContentNotification1ContentNotification1Content" +
									"Notification1ContentNotification1ContentNotification1ContentNotification1ContentNotification1ContentNotification1ContentNotification1ContentNotification1Content" +
									"Notification1ContentNotification1ContentNotification1ContentNotification1ContentNotification1ContentNotification1ContentNotification1ContentNotification1Content" +
									"Notification1ContentNotification1ContentNotification1ContentNotification1ContentNotification1ContentNotification1ContentNotification1ContentNotification1Content",
								},
								IsChecked = true
							},
							new UserNotificationEntity
							{
								Notification = new NotificationEntity
							{
								Header = "Notification2Header",
								Content = "Notification2ContentNotification2ContentNotification1ContentNotification1ContentNotification1ContentNotification1ContentNotification1ContentNotification1Content" +
								"Notification1ContentNotification1ContentNotification1ContentNotification1ContentNotification1ContentNotification1ContentNotification1ContentNotification1Content" +
								"Notification1ContentNotification1ContentNotification1ContentNotification1ContentNotification1ContentNotification1ContentNotification1ContentNotification1Content" +
								"Notification1ContentNotification1ContentNotification1ContentNotification1ContentNotification1ContentNotification1ContentNotification1ContentNotification1Content"
							}
							},
							
						}
					}
				});

				context.SaveChanges();

                if (!context.Manufacturers.Any())
                {
                    context.Manufacturers.Add(new ManufacturerEntity { 
						Name = "BMW",
						PhoneNumber = "88005553535",
						City = "Мильберстхофен",
						OfficialWebsite = "https://www.bmw.ru/ru/index.html",
						Description = "BMW, или Bayerische Motoren Werke AG, — это один из ведущих производителей автомобилей и мотоциклов в мире, основанный в 1916 году в Мюнхене, " +
						"Германия. На протяжении более чем столетия компания зарекомендовала себя как символ качества, инноваций и превосходного дизайна. BMW активно внедряет новейшие" +
						" технологии в разработку своих автомобилей, обеспечивая высокую производительность, безопасность и комфорт. Миссия компании заключается в создании автомобилей," +
						" которые пробуждают эмоции и дарят уникальный опыт вождения. \n Ключевыми принципами BMW являются устойчивое развитие и ответственность перед обществом. " +
						"В последние годы компания сосредоточилась на разработке электрифицированных моделей и устойчивых производственных практиках. Линейка BMW i включает в себя " +
						"инновационные электромобили и гибридные модели, что подчеркивает стремление компании к экологии и заботе о будущем планеты. BMW также активно работает в " +
						"направлениях автоматизации и цифровизации, предлагая своим клиентам современные решения и услуги, такие как интеллектуальные системы управления и интеграция " +
						"с мобильными устройствами. \n Инновационный подход и безупречное качество делают BMW лидером рынка в сегменте премиум-автомобилей. Каждая модель BMW создается с" +
						" учетом не только технологических аспектов, но и потребностей водителей, предлагая индивидуальный подход к каждому клиенту. Своим поклонникам компания предлагает" +
						" разнообразные программы обслуживания и опыт взаимодействия с брендом через эксклюзивные мероприятия, тест-драйвы и специализированные предложения. BMW — это " +
						"не просто автомобили, это стиль жизни, который становится доступным каждому, кто ценит высокие технологии, элегантный дизайн и динамику вождения.",
						Images = new List<ManufacturerImageEntity>
						{
							new ManufacturerImageEntity
							{
								Name = "BMW-Manufacturer-1",
								Path = "manufacturers-image-bucket/BMW-Manufacturer-1.jpg"
							},
							new ManufacturerImageEntity
							{
								Name = "BMW-Manufacturer-2",
								Path = "manufacturers-image-bucket/BMW-Manufacturer-2.jpg"
							},
							new ManufacturerImageEntity
							{
								Name = "BMW-Manufacturer-3",
								Path = "manufacturers-image-bucket/BMW-Manufacturer-3.jpg"
							},
							new ManufacturerImageEntity
							{
								Name = "BMW-Manufacturer-4",
								Path = "manufacturers-image-bucket/BMW-Manufacturer-4.jpg"
							},
							new ManufacturerImageEntity
							{
								Name = "BMW-Manufacturer-5",
								Path = "manufacturers-image-bucket/BMW-Manufacturer-5.jpg"
							},
							new ManufacturerImageEntity
							{
								Name = "BMW-Manufacturer-6",
								Path = "manufacturers-image-bucket/BMW-Manufacturer-6.jpg"
							},
							new ManufacturerImageEntity
							{
								Name = "BMW-Manufacturer-7",
								Path = "manufacturers-image-bucket/BMW-Manufacturer-7.jpg"
							},
							new ManufacturerImageEntity
							{
								Name = "BMW-Manufacturer-8",
								Path = "manufacturers-image-bucket/BMW-Manufacturer-8.jpg"
							}
						}
					});
                    context.SaveChanges();

                }
                if (!context.Cars.Any())
                {
                    var manufacturer = context.Manufacturers.FirstOrDefault();
                    var cars = new List<CarEntity>
                    {
                        new CarEntity{
                            Name = "BMW X3 2018",
                            Manufacturer = manufacturer,
							ShortDescription = "BMW X3 2018 - это кроссовер класса люкс, который сочетает в себе высокую производительность, комфорт " +
									"и стильный дизайн. Автомобиль оснащен мощным двигателем, который обеспечивает плавное ускорение и отличную управляемость" +
									" на дороге. Внутреннее пространство выполнено из высококачественных материалов, создавая атмосферу роскоши и комфорта" +
									" для пассажиров. BMW X3 2018 также обладает передовыми технологиями, включая инфотейнмент систему, навигацию и системы" +
									" безопасности, что делает его идеальным выбором для тех, кто ценит высокий уровень комфорта и безопасности при вождении.",
							Price = 4399000,
							Users = context.Users.ToList(),
							Offers = new OffersEntity
							{
								IsSale = true,
								IsSell = true
							},
							CurrencyType = CurrencyType.Rub,
							Images = new List<ImageEntity>
							{
								new ImageEntity
								{
									Name = "BMW X3 2018-1",
									Path = "cars-image-bucket/BMW X3 2018-1.jpg"
								},
								new ImageEntity
								{
									Name = "BMW X3 2018-2",
									Path = "cars-image-bucket/BMW X3 2018-2.jpg"
								},
								new ImageEntity
								{
									Name = "BMW X3 2018-3",
									Path = "cars-image-bucket/BMW X3 2018-3.jpg"
								}
							}
						},
                        new CarEntity{
                            Name = "BMW 4 серии 2014",
                            ShortDescription = "BMW 4 серии 2014 года - это стильный и спортивный автомобиль с элегантным дизайном кузова" +
									" и высоким уровнем производительности. Он оснащен мощным двигателем, который обеспечивает высокую динамику " +
									"и отличную управляемость. В салоне автомобиля присутствует высококачественная отделка и передовые технологии," +
									" которые обеспечивают комфорт и безопасность во время поездок. BMW 4 серии 2014 - это идеальный выбор для тех," +
									" кто ценит стиль, качество и динамичный образ жизни.",
							CurrencyType = CurrencyType.Rub,
							Manufacturer = manufacturer,
							Price = 2899000,
							Offers = new OffersEntity
							{
								IsSale = true
							},
							Images = new List<ImageEntity>
							{
								new ImageEntity
								{
									Name = "BMW 4 серии 2014-1",
									Path = "cars-image-bucket/BMW 4 серии 2014-1.jpg"
								},
								new ImageEntity
								{
									Name = "BMW 4 серии 2014-2",
									Path = "cars-image-bucket/BMW 4 серии 2014-2.jpg"
								},
								new ImageEntity
								{
									Name = "BMW 4 серии 2014-3",
									Path = "cars-image-bucket/BMW 4 серии 2014-3.jpg"
								}
							}
						},
						new CarEntity{
							Name = "BMW X5 2017",
							ShortDescription = "BMW X5 2017 - это внушительный и роскошный SUV, который сочетает в себе высокую производительность и стильный дизайн. " +
									"Этот автомобиль оснащен мощным и эффективным двигателем, который обеспечивает плавное и быстрое ускорение. Салон X5 2017 выполнен из " +
									"высококачественных материалов, с элегантным дизайном и множеством современных технологий, таких как навигационная система, система " +
									"управления мультимедиа и светодиодные фары. Кроме того, этот автомобиль обладает прекрасной управляемостью и комфортной поездкой как" +
									" по городским улицам, так и на открытых дорогах. BMW X5 2017 - идеальный выбор для тех, кто ценит роскошь и динамичность в одном автомобиле.",
							Manufacturer = manufacturer,
							CurrencyType = CurrencyType.Rub,
							Price = 3688000,
							Offers = new OffersEntity
							{
								IsSale = false
							},
							Images = new List<ImageEntity>
							{
								new ImageEntity
								{
									Name = "BMW X5 2017-1",
									Path = "cars-image-bucket/BMW X5 2017-1.jpg"
								},
								new ImageEntity
								{
									Name = "BMW X5 2017-2",
									Path = "cars-image-bucket/BMW X5 2017-2.jpg"
								},
								new ImageEntity
								{
									Name = "BMW X5 2017-3",
									Path = "cars-image-bucket/BMW X5 2017-3.jpg"
								}
							}
						},
						new CarEntity
						{
							Name = "BMW X6 2015",
							ShortDescription = "BMW X6 2015 - это роскошный и стильный кроссовер, который сочетает в себе " +
									"элегантный дизайн, высокую производительность и передовые технологии. Этот автомобиль оборудован " +
									"мощным двигателем, обеспечивающим плавное и динамичное ускорение, а также комфортным салоном с " +
									"премиальными материалами и передовыми системами безопасности. BMW X6 2015 идеально подойдет как " +
									"для ежедневных поездок по городу, так и для путешествий на дальние расстояния, предоставляя своему" +
									" владельцу высочайший уровень комфорта и удовольствия от вождения.",
							Manufacturer = manufacturer,
							CurrencyType = CurrencyType.Rub,
							Offers = new OffersEntity
							{
								IsSale = true,
								IsSell = true
							},
							Price = 3980000,
							OldPrice = 4299999,
							Images = new List<ImageEntity>
							{
								new ImageEntity
								{
									Name = "BMW X6 2015-1",
									Path = "cars-image-bucket/BMW X6 2015-1.jpg"
								},
								new ImageEntity
								{
									Name = "BMW X6 2015-2",
									Path = "cars-image-bucket/BMW X6 2015-2.jpg"
								},
								new ImageEntity
								{
									Name = "BMW X6 2015-3",
									Path = "cars-image-bucket/BMW X6 2015-3.jpg"
								}
							}
						},
						new CarEntity
						{
							Name = "BMW X6 M 2023",
							ShortDescription = "BMW X6 M 2023 - это мощный и элегантный спортивный кроссовер, " +
									"который предлагает уникальное сочетание стиля, комфорта и производительности. " +
									"Автомобиль оснащен высокотехнологичным двигателем мощностью более 600 лошадиных " +
									"сил, что позволяет ему разгоняться до 100 км/ч всего за несколько секунд. Особенности " +
									"данной модели включают в себя спортивный дизайн с агрессивными линиями, большие диски с " +
									"покрышками высокого класса, а также улучшенную аэродинамику для максимальной производительности. " +
									"Внутреннее пространство автомобиля оборудовано самыми современными технологиями, включая " +
									"цифровую приборную панель, мультимедийную систему и систему навигации. BMW X6 M 2023 " +
									"идеально подойдет для тех, кто ценит роскошь, комфорт и скорость. Этот автомобиль будет " +
									"отличным выбором для тех, кто желает иметь идеальное сочетание производительности и стиля.",
							Manufacturer = manufacturer,
							CurrencyType = CurrencyType.Rub,
							Price = 23689000,
							Offers = new OffersEntity
							{
								IsSale = true,
								IsSell = false
							},
							Images = new List<ImageEntity>
							{
								new ImageEntity
								{
									Name = "BMW X6 M 2023-1",
									Path = "cars-image-bucket/BMW X6 M 2023-1.jpg"
								},
								new ImageEntity
								{
									Name = "BMW X6 M 2023-2",
									Path = "cars-image-bucket/BMW X6 M 2023-2.jpg"
								},
								new ImageEntity
								{
									Name = "BMW X6 M 2023-3",
									Path = "cars-image-bucket/BMW X6 M 2023-3.jpg"
								}
							}
						},
						new CarEntity
						{
							Name = "BMW X5 M 2021",
							ShortDescription = "BMW X5 M 2021 - это спортивный внедорожник высшего класса, сочетающий в себе мощность, роскошь и" +
									" технологии. Он оснащен мощным 4,4-литровым твин-турбо V8 двигателем, который развивает более 600 лошадиных сил. " +
									"Современные технологии и системы безопасности делают вождение комфортным и безопасным. Внутри автомобиля просторный " +
									"и роскошный салон, оборудованный самыми современными возможностями развлечений и комфорта. BMW X5 M 2021 - идеальный " +
									"выбор для тех, кто ценит роскошное и высокотехнологичное вождение.",
							Manufacturer = manufacturer,
							CurrencyType = CurrencyType.Rub,
							Price = 14999000,
							Images = new List<ImageEntity>
							{
								new ImageEntity
								{
									Name = "BMW X5 M 2021-1",
									Path = "cars-image-bucket/BMW X5 M 2021-1.jpg"
								},
								new ImageEntity
								{
									Name = "BMW X5 M 2021-2",
									Path = "cars-image-bucket/BMW X5 M 2021-2.jpg"
								},
								new ImageEntity
								{
									Name = "BMW X5 M 2021-3",
									Path = "cars-image-bucket/BMW X5 M 2021-3.jpg"
								}
							}
						},
						new CarEntity
						{
							Name = "BMW 2 серии 2020",
							ShortDescription = "BMW 2 серии 2020 - это стильный и спортивный автомобиль, созданный для настоящих ценителей динамичного вождения. " +
									"Он сочетает в себе элегантный дизайн и высокую производительность. В этой модели использованы самые современные технологии и " +
									"инновационные функции, которые делают ее одним из лидеров в своем классе. В салоне BMW 2 серии 2020 вы найдете премиальные " +
									"материалы, удобные сиденья и передовую информационно-развлекательную систему. Этот автомобиль предлагает отличную управляемость, " +
									"динамичное ускорение и надежность на любой дороге.",
							Manufacturer = manufacturer,
							CurrencyType = CurrencyType.Rub,
							Price = 3250000,
							Images = new List<ImageEntity>
							{
								new ImageEntity
								{
									Name = "BMW 2 серии 2020-1",
									Path = "cars-image-bucket/BMW 2 серии 2020-1.jpg"
								},
								new ImageEntity
								{
									Name = "BMW 2 серии 2020-2",
									Path = "cars-image-bucket/BMW 2 серии 2020-2.jpg"
								},
								new ImageEntity
								{
									Name = "BMW 2 серии 2020-3",
									Path = "cars-image-bucket/BMW 2 серии 2020-3.jpg"
								}
							}
						},
						new CarEntity
						{
							Name = "BMW X1 2020",
							Manufacturer = manufacturer,
							ShortDescription = "BMW X1 2020 - это стильный и производительный кроссовер компактного класса, который" +
									" сочетает в себе спортивный дизайн, комфорт и технологии наивысшего уровня. Автомобиль оснащен мощным" +
									" и экономичным двигателем, обеспечивающим отличную динамику и управляемость на дороге. Внутреннее " +
									"пространство удобно и функционально организовано, современные системы безопасности и развлечений " +
									"обеспечивают высокий уровень комфорта и удовольствия от вождения. BMW X1 2020 - это идеальный выбор " +
									"для тех, кто ценит надежность, стиль и инновации в автомобильном мире.",
							Price = 4199000,
							CurrencyType = CurrencyType.Rub,
							Images = new List<ImageEntity>
							{
								new ImageEntity
								{
									Name = "BMW X1 2020-1",
									Path = "cars-image-bucket/BMW X1 2020-1.jpg"
								},
								new ImageEntity
								{
									Name = "BMW X1 2020-2",
									Path = "cars-image-bucket/BMW X1 2020-2.jpg"
								},
								new ImageEntity
								{
									Name = "BMW X1 2020-3",
									Path = "cars-image-bucket/BMW X1 2020-3.jpg"
								}
							}
						},
						new CarEntity
						{
							Name = "BMW 3 серии 2013",
							ShortDescription = "BMW 3 Серия 2013 года - это стильное и спортивное седан, сочетающее в себе роскошный дизайн," +
									" высокие технологии и динамичные характеристики. Автомобиль оснащен мощными бензиновыми и дизельными двигателями," +
									" которые обеспечивают отличную производительность и динамику. Внутри салон выполнен из высококачественных" +
									" материалов, и предлагает просторное пространство для пассажиров и багажа. Также в автомобиле присутствует" +
									" множество передовых технологий, таких как система навигации, адаптивный круиз-контроль, система помощи при" +
									" парковке и многое другое. BMW 3 Серия 2013 года является идеальным выбором для тех, кто ценит комфорт, стиль " +
									"и высокую производительность.",
							Price = 4199000,
							CurrencyType = CurrencyType.Rub,
							Manufacturer = manufacturer,
							Images = new List<ImageEntity>
							{
								new ImageEntity
								{
									Name = "BMW 3 серии 2013-1",
									Path = "cars-image-bucket/BMW 3 серии 2013-1.jpg"
								},
								new ImageEntity
								{
									Name = "BMW 3 серии 2013-2",
									Path = "cars-image-bucket/BMW 3 серии 2013-2.jpg"
								},
								new ImageEntity
								{
									Name = "BMW 3 серии 2013-3",
									Path = "cars-image-bucket/BMW 3 серии 2013-3.jpg"
								}
							}
						},
						new CarEntity
						{
							Name = "BMW X6 2021",
							ShortDescription = "BMW X6 2021 - это элегантный и мощный кроссовер, который привлекает внимание своим " +
									"динамичным дизайном и выдающейся производительностью. Снаружи автомобиль имеет агрессивный и спортивный " +
									"стиль, с выразительными линиями и характерной решеткой радиатора.Внутри X6 2021 просторный и уютный салон, " +
									"оформленный высококачественными материалами, современной технологией и эргономичным дизайном. " +
									"Водитель и пассажиры могут наслаждаться комфортабельными сиденьями, удобным мультимедийным " +
									"интерфейсом и полным набором современных опций.Под капотом BMW X6 2021 можно найти мощные" +
									" бензиновые и дизельные двигатели, которые обеспечивают высокую производительность и эффективность." +
									" Автомобиль оснащен передовыми системами безопасности и управления, что делает его одним из лучших выборов в своем классе.",
							Price = 11479000,
							CurrencyType = CurrencyType.Rub,
							Manufacturer = manufacturer,
							Images = new List<ImageEntity>
							{
								new ImageEntity
								{
									Name = "BMW X6 2021-1",
									Path = "cars-image-bucket/BMW X6 2021-1.jpg"
								},
								new ImageEntity
								{
									Name = "BMW X6 2021-2",
									Path = "cars-image-bucket/BMW X6 2021-2.jpg"
								},
								new ImageEntity
								{
									Name = "BMW X6 2021-3",
									Path = "cars-image-bucket/BMW X6 2021-3.jpg"
								}
							}
						},
						new CarEntity
						{
							Name = "BMW X1 2011",
							ShortDescription = "BMW X1 2011 - премиальный компактный кроссовер от немецкого производителя BMW. Автомобиль " +
									"отличается стильным и динамичным дизайном, характерным для всех моделей бренда BMW. Внутри X1 2011 предлагает" +
									" просторный и комфортабельный салон с качественными материалами отделки. Автомобиль оснащен мощными и " +
									"эффективными двигателями, которые обеспечивают отличную динамику и экономичность. BMW X1 2011 также обладает" +
									" отличной управляемостью и уверенным поведением на дороге благодаря передовой технологии подвески и системы " +
									"управления. Этот автомобиль идеально подходит для городской езды и дальних поездок, сочетая в себе стиль, комфорт и производительность.",
							Manufacturer = manufacturer,
							CurrencyType = CurrencyType.Rub,
							Price = 1289000,
							OldPrice = 1599999,
							Images = new List<ImageEntity>
							{
								new ImageEntity
								{
									Name = "BMW X1 2011-1",
									Path = "cars-image-bucket/BMW X1 2011-1.jpg"
								},
								new ImageEntity
								{
									Name = "BMW X1 2011-2",
									Path = "cars-image-bucket/BMW X1 2011-2.jpg"
								},
								new ImageEntity
								{
									Name = "BMW X1 2011-3",
									Path = "cars-image-bucket/BMW X1 2011-3.jpg"
								}
							}
						}
					};
                    context.Cars.AddRange(cars);
                    context.SaveChanges();
                }
			}
			
			using (var minioClinet = services.BuildServiceProvider().GetRequiredService<IMinioClientFactory>().CreateClient())
			{
				var argsImageBucket = new BucketExistsArgs()
					.WithBucket("cars-image-bucket");
				var argsManufacturerBucket = new BucketExistsArgs()
					.WithBucket("manufacturers-image-bucket");

				var ImageBucketExist = minioClinet.BucketExistsAsync(argsImageBucket).ConfigureAwait(false).GetAwaiter().GetResult();
				var ManufacturerBucketExist = minioClinet.BucketExistsAsync(argsManufacturerBucket).ConfigureAwait(false).GetAwaiter().GetResult();

				if (!ImageBucketExist)
				{
					var createImageBucketArgs = new MakeBucketArgs().WithBucket("cars-image-bucker");
					minioClinet.MakeBucketAsync(createImageBucketArgs).Wait();
				}
				if (!ManufacturerBucketExist)
				{
					var createaManufacturerBucketArgs = new MakeBucketArgs().WithBucket("manufacturers-image-bucket");
					minioClinet.MakeBucketAsync(createaManufacturerBucketArgs).Wait();
				}
			}

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(builder =>
            {
				builder.WithOrigins("http://localhost:3000")
					.AllowAnyMethod()
					.AllowAnyHeader()
					.AllowCredentials();
			});
            app.UseSwagger(options =>
            {
                options.SerializeAsV2 = true;
            });
            app.UseSwaggerUI(options =>
            {
                options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                options.RoutePrefix = string.Empty;
            });
            app.UseRouting();
            app.UseAppAuth();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Car}/{action=Get}");
            });
        }
    }
}