﻿using Entities;
using Reposetories;
using System.ComponentModel;

namespace Repository
{
    public class GiftsReposetory : IGiftsReposetory
    {
        static int Identity = 1;
        public static List<Gift> gifts = [new Gift() { Id = Identity++, Name = "Half of the Donation", Description = "Receive half of the total money donated", imgUrl = "halfDonation.jpeg", donorId = 1 },
            new Gift() { Id = Identity++, Name = "Luxury Car", Description = "A brand new luxury car", imgUrl = "car.jpeg", donorId = 6 },
            new Gift() { Id = Identity++, Name = "Mountain Bike", Description = "High-quality mountain bike", imgUrl = "bike.jpeg", donorId = 3 },
            new Gift() { Id = Identity++, Name = "Romantic Flight", Description = "Flight for two to Austria", imgUrl = "flightToAustria.jpeg", donorId = 4 },
            new Gift() { Id = Identity++, Name = "Yearly Cleaning Service", Description = "Professional home cleaning service for a year", imgUrl = "cleaningService.jpeg", donorId = 5 },
            new Gift() { Id = Identity++, Name = "Coffee Machine", Description = "State-of-the-art coffee machine", imgUrl = "CoffeeMachine.jpeg", donorId = 7 },
            new Gift() { Id = Identity++, Name = "Designer Couch", Description = "Modern designer couch", imgUrl = "DesignerCouch.jpeg", donorId = 8 },
            new Gift() { Id = Identity++, Name = "Professional Camera", Description = "High-resolution professional camera", imgUrl = "Camera.jpeg", donorId = 9 },
            new Gift() { Id = Identity++, Name = "Smart Watch", Description = "Advanced smart watch with health tracking", imgUrl = "SmartWatch.jpeg", donorId = 10 },
            new Gift() { Id = Identity++, Name = "Washing Machine", Description = "Energy-efficient washing machine", imgUrl = "WashingMachine.jpeg", donorId = 11 },
            new Gift() { Id = Identity++, Name = "Luxury Sofa Set", Description = "Premium sofa set for your living room", imgUrl = "SofaSet.jpeg", donorId = 12 },
            new Gift() { Id = Identity++, Name = "Gaming Console", Description = "Latest generation gaming console", imgUrl = "GamingConsole.jpeg", donorId = 1 },
            new Gift() { Id = Identity++, Name = "Home Theater System", Description = "High-quality surround sound system", imgUrl = "HomeTheater.jpeg", donorId = 1 },
            new Gift() { Id = Identity++, Name = "Designer Watch", Description = "Luxury designer watch", imgUrl = "DesignerWatch.jpeg", donorId = 3 },
            new Gift()
            {
                Id = Identity++,
                Name = "Night Jeep Tour",
                Description = "An adventurous jeep tour at night",
                imgUrl = "JeepTour.jpeg",
                donorId = 3
            },
            new Gift()
            {
                Id = Identity++,
                Name = "Designer Table and Dishes",
                Description = "A beautifully designed table with matching dishes",
                imgUrl = "TableAndDishes.jpeg",
                donorId = 4
            },
            new Gift()
            {
                Id = Identity++,
                Name = "Seating Area",
                Description = "Cozy seating area for your living room",
                imgUrl = "SeatingArea.jpeg",
                donorId = 5
            },
            new Gift()
            {
                Id = Identity++,
                Name = "Printer",
                Description = "High-quality printer for home or office use",
                imgUrl = "Printer.jpeg",
                donorId = 6
            },
            new Gift()
            {
                Id = Identity++,
                Name = "Microwave",
                Description = "Compact and efficient microwave oven",
                imgUrl = "Microwave.jpeg",
                donorId = 7
            },
            new Gift()
            {
                Id = Identity++,
                Name = "Sound System",
                Description = "High-quality sound system for home theater",
                imgUrl = "SoundSystem.jpeg",
                donorId = 8
            },
            new Gift()
            {
                Id = Identity++,
                Name = "Computer",
                Description = "Latest model computer with high specifications",
                imgUrl = "Computer.jpeg",
                donorId = 9
            }
        ];
        public async Task<List<Gift>> getGifts()
        {
            return gifts; ;



        }
        public async Task<Gift> getById(int id)
        {

            return gifts.FirstOrDefault<Gift>(currenGift => currenGift.Id == id);


        }
        public async Task<Gift> createGift(Gift gift)
        {
            gift.Id = Identity++;
            gifts.Add(gift);
            return (gift);
        }

        public async Task<Gift> updateGift(int id, Gift giftToUpdate)
        {
            Gift? gift = gifts.Find(currenGift => currenGift.Id == id);
            
            if (gift == null)
            {
                return null;
            }
            gift.Price = giftToUpdate.Price;
            gift.Description = giftToUpdate.Description;
            gift.donorId = giftToUpdate.donorId;
            gift.Name= giftToUpdate.Name;
            gift.imgUrl = giftToUpdate.imgUrl;
            return (gift);

        }
        public async Task<bool> deleteGift(int id)
        {
            if (RaffleReposetory.raffleTickets.FirstOrDefault<LotteryTicket>(currenTicket => currenTicket.GiftId == id) == null)
            {
                gifts.RemoveAll(currenGift => currenGift.Id == id);
                return true;

            }
            return false;
        }
        public async Task<Boolean> isUnique(Gift gift)
        {
            Gift? foundGift = gifts.FirstOrDefault(currentGift => currentGift.Id != gift.Id && currentGift.Name == gift.Name);
            return foundGift!=null ? false : true;

        }

    }
}
