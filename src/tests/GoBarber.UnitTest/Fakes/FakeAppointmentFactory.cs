using Bogus;
using GoBarber.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace GoBarber.UnitTest.Fakes
{
    public class FakeAppointmentFactory
    {
        public static AppointmentEntity CreateAppointment()
        {
            var mockAppointment = new Faker<AppointmentEntity>()
                .RuleFor(u => u.Date, (f, u) => f.Date.Future());

            var appointment = mockAppointment.Generate();

            return appointment;
        }
    }
}
